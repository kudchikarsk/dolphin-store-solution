using AutoMapper;
using DA.ClientManagement.Data;
using DA.SharedKernel.Interfaces;
using DA.TonerJobManagement.Core.Aggregates.Models;
using DA.TonerJobManagement.Core.Interfaces;
using DA.TonerJobManagement.Data;
using DA.TonerJobManagement.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers.API
{
    public class TonerJobController : ApiController
    {
        private readonly IRepository<TonerJob> repository;
        private readonly ITonerRepository tonerRepository;
        private readonly IStockItemRepository stockItemRepository;
        private readonly IPurchaseItemRepository purchaseItemRepository;

        public TonerJobController(IRepository<TonerJob> repository,
            ITonerRepository tonerRepository,
            IStockItemRepository stockItemRepository, 
            IPurchaseItemRepository purchaseItemRepository)
        {
            this.repository = repository;
            this.tonerRepository = tonerRepository;
            this.stockItemRepository = stockItemRepository;
            this.purchaseItemRepository = purchaseItemRepository;
        }

        // GET: api/TonerJob
        public IEnumerable<TonerJobViewModel> Get(string fromDate=null, string toDate=null)
        {
            var inDate = DateTime.Today;
            var outDate = DateTime.Today;

            if (fromDate != null && toDate != null)
            {
                try
                {
                    var pattern = "ddd MMM dd yyyy";
                    inDate = DateTime.ParseExact(fromDate,pattern,null,DateTimeStyles.None).Date;
                    outDate = DateTime.ParseExact(toDate, pattern, null, DateTimeStyles.None).Date;
                }
                catch (FormatException) { }
            }
            else if (fromDate != null)
            {
                try
                {
                    inDate = DateTime.Parse(fromDate).Date;
                    outDate = DateTime.Parse(fromDate).Date;
                }
                catch (FormatException) { }
            }

            var tonerJobs=repository.Get(filter: (t) => (t.In >= inDate  && t.Out <= outDate) || (t.In >= inDate && t.In <= outDate) || (t.Out >= inDate && t.Out <= outDate), includeProperties: "PurchasedItems.StockItem,Toners");
            return tonerJobs.Select(t=>t.ToViewModel());
        }

        // GET: api/Employee/5
        public TonerJobViewModel Get(int id)
        {
            var tonerJob = repository.Get(filter: (t) => t.Id==id, includeProperties: "PurchasedItems.StockItem,Toners").Single();
            return tonerJob.ToViewModel();
        }

        // POST: api/Employee
        public TonerJobViewModel Post([FromBody]TonerJobViewModel value)
        {
            var tonerJob = TonerJob.Create(
                value.ClientId,
                GetToners(value.Toners),
                value.CollectedById,
                value.DeliveredById,
                value.In.Date,
                value.Out.Date,
                CreatePurchasedItems(value.PurchasedItems),
                value.Remarks       ,
                value.OtherCharges  ,
                value.Discount
                );
            repository.Insert(tonerJob);
            return tonerJob.ToViewModel();
        }

        // PUT: api/Employee/5
        public TonerJobViewModel Put(long id, [FromBody]TonerJobViewModel value)
        {
            var tonerJob = repository.Get(filter: (t) => t.Id == id, includeProperties: "PurchasedItems.StockItem,Toners").Single();
            tonerJob.UpdateAmount(value.Target);
            tonerJob.UpdateIn(value.In.Date);
            tonerJob.UpdateOut(value.Out.Date);
            tonerJob.UpdatePurchaseItems(CreatePurchasedItems(value.PurchasedItems));
            repository.Update(tonerJob);
            return tonerJob.ToViewModel();
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
            var tonerJob = repository.Get(filter: (t) => t.Id == id, includeProperties: "PurchasedItems.StockItem,Toners").Single();
            var itemsToDelete = tonerJob.PurchasedItems.ToList();
            tonerJob.ReturnPurchaseItems();
            repository.Delete(tonerJob);
            itemsToDelete.ForEach(p => purchaseItemRepository.Delete(p));            
        }

        private List<Toner> GetToners(List<TonerViewModel> toners)
        {
            return toners.Select(t => tonerRepository.GetTonerById(t.Id)).ToList();
        }

        private List<PurchaseItem> CreatePurchasedItems(List<PurchaseItemViewModel> purchasedItems)
        {
            return purchasedItems.Select(p => PurchaseItem.Create(stockItemRepository.GetStockItemById(p.StockItem.Id),p.Quantity)).ToList();
        }
    }

    public static class TonerJobExtension
    {
        public static TonerJobViewModel ToViewModel(this TonerJob tonerJob) {
            var clientContext = new ClientContext();
            var tonerJobViewModel = Mapper.Map<TonerJobViewModel>(tonerJob);
            tonerJobViewModel.ClientName = clientContext.Clients.Where(c => c.Id == tonerJob.ClientId).Single().Name;
            tonerJobViewModel.CollectedByName = clientContext.Employees.Where(c => c.Id == tonerJob.CollectedById).Single().Name;
            tonerJobViewModel.DeliveredByName = clientContext.Employees.Where(c => c.Id == tonerJob.DeliveredById).Single().Name;
            return tonerJobViewModel;
        }
    }
}
