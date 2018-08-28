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

namespace WebAPI.Controllers
{
    public class TonerController : ApiController
    {
        private readonly IRepository<Toner> repository;

        public TonerController(IRepository<Toner> repository)
        {
            this.repository = repository;
        }

        // GET: api/Toner
        public IEnumerable<TonerVM> Get(long clientId, string name=null)
        {
            return repository.Get(t => t.ClientId == clientId && (name == null || t.Name.ToLower().Contains(name.ToLower()))).Select(t=>Mapper.Map<TonerVM>(t)).ToList();
        }

        
        // POST: api/Toner
        public TonerVM Post([FromBody]TonerVM value)
        {
            var toner = Toner.Create(value.Name, value.ClientId);
            repository.Insert(toner);
            return Mapper.Map<TonerVM>(toner);
        }

        // PUT: api/Toner/5
        public TonerVM Put(long id, [FromBody]TonerVM value)
        {
            var toner = repository.GetByID(value.Id);
            toner.Update(value.Name, value.ClientId);
            repository.Update(toner);
            return Mapper.Map<TonerVM>(toner);
        }

        // DELETE: api/Toner/5
        public void Delete(long id)
        {
            repository.Delete(id);
        }
    }
}
