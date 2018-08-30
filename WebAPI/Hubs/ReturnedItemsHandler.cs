using DA.SharedKernel.Interfaces;
using S = DA.StockManagement.Core.Models;
using DA.StockManagement.Data;
using DA.StockManagement.Data.Repositories;
using TJ = DA.TonerJobManagement.Core.Aggregates.Models;
using DA.TonerJobManagement.Core.Models.Events;
using DA.TonerJobManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Hubs
{
    public class ReturnedItemsHandler : IHandle<ReturnedItemsEvent>
    {
        IRepository<S.StockItem> repository;
        private readonly IRepository<TJ.PurchaseItem> purchaseItemsRepository;

        public ReturnedItemsHandler(IRepository<S.StockItem> repository, IRepository<TJ.PurchaseItem> purchaseItemsRepository)
        {
            this.repository = repository;
            this.purchaseItemsRepository = purchaseItemsRepository;
        }

        public void Handle(ReturnedItemsEvent args)
        {
            foreach (var item in args.ReturnedItems)
            {
                var stockItem = repository.GetByID(item.StockItem.Id);
                stockItem.ReturnedQuantity(item.Quantity);
                repository.Update(stockItem);
                purchaseItemsRepository.Delete(item);
            }
        }
    }
}