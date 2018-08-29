using AutoMapper;
using DA.ClientManagement.Core.Models;
using DA.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers.API
{
    public class TonerController : ApiController
    {
        private readonly IRepository<Toner> repository;

        public TonerController(IRepository<Toner> repository)
        {
            this.repository = repository;
        }

        // GET: api/Toner
        public IEnumerable<TonerViewModel> Get(long clientId, string name=null)
        {
            return repository.Get(t => t.ClientId == clientId && (name == null || t.Name.ToLower().Contains(name.ToLower()))).Select(t=>Mapper.Map<TonerViewModel>(t)).ToList();
        }

        
        // POST: api/Toner
        public TonerViewModel Post([FromBody]TonerViewModel value)
        {
            var toner = Toner.Create(value.Name, value.ClientId);
            repository.Insert(toner);
            return Mapper.Map<TonerViewModel>(toner);
        }

        // PUT: api/Toner/5
        public TonerViewModel Put(long id, [FromBody]TonerViewModel value)
        {
            var toner = repository.GetByID(value.Id);
            toner.Update(value.Name, value.ClientId);
            repository.Update(toner);
            return Mapper.Map<TonerViewModel>(toner);
        }

        // DELETE: api/Toner/5
        public void Delete(long id)
        {
            repository.Delete(id);
        }
    }
}
