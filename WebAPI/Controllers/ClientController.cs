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
    public class ClientController : ApiController
    {
        private readonly IRepository<Client> repository;

        public ClientController(IRepository<Client> repository)
        {
            this.repository = repository;
        }

        // GET: api/Client
        public IEnumerable<ClientVM> Get(string name=null)
        {
            return repository.Get(filter:(c)=>name==null || c.Name.ToLower().Contains(name.ToLower())).Select(c=>Mapper.Map<ClientVM>(c));
        }

        // GET: api/Client/5
        public ClientVM Get(long id)
        {
            return repository.Get(c => c.Id == id).Select(c=>Mapper.Map<ClientVM>(c)).FirstOrDefault();
        }

        // POST: api/Client
        public ClientVM Post([FromBody]ClientVM value)
        {
            var client = Client.Create(
                value.Name,
                value.Address,
                value.Mobile,
                value.Email
                );
            repository.Insert(client);
            return Mapper.Map<ClientVM>(client);
        }

        // PUT: api/Client/5
        public ClientVM Put(long id, [FromBody]ClientVM value)
        {
            var client = repository.GetByID(value.Id);
            client.Update(
                value.Name,
                value.Address,
                value.Mobile,
                value.Email
                );
            repository.Update(client);
            return Mapper.Map<ClientVM>(client);
        }

        // DELETE: api/Client/5
        public void Delete(long id)
        {
            repository.Delete(id);
        }
    }
}
