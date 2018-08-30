using AutoMapper;
using DA.SharedKernel.Interfaces;
using DA.StockManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers.API
{
    public class StockItemController : ApiController
    {
        private readonly IRepository<StockItem> repository;

        public StockItemController(IRepository<StockItem> repository)
        {
            this.repository = repository;
        }

        // GET: api/Employee
        public IEnumerable<StockItemViewModel> Get(string name = null)
        {
            return repository.Get(filter: (e) => name == null || e.Name.ToLower().Contains(name.ToLower())).Select(e => Mapper.Map<StockItemViewModel>(e));
        }

        // GET: api/Employee/5
        public StockItemViewModel Get(int id)
        {
            var employee = repository.GetByID(id);
            return Mapper.Map<StockItemViewModel>(employee);
        }

        // POST: api/Employee
        public StockItemViewModel Post([FromBody]StockItemViewModel value)
        {
            var employee = StockItem.Create(
                value.Name,
                value.Quantity,
                value.SellingPrice,
                value.CostPrice
                );
            repository.Insert(employee);
            return Mapper.Map<StockItemViewModel>(employee);
        }

        // PUT: api/Employee/5
        public StockItemViewModel Put(long id, [FromBody]StockItemViewModel value)
        {
            var employee = repository.GetByID(value.Id);
            employee.Update(
                value.Name,
                value.Quantity,
                value.SellingPrice,
                value.CostPrice
                );
            repository.Update(employee);
            return Mapper.Map<StockItemViewModel>(employee);
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
