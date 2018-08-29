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
    public class ClientController : ApiController
    {
        private readonly IRepository<Client> repository;

        public ClientController(IRepository<Client> repository)
        {
            this.repository = repository;
        }

        // GET: api/Client
        public IEnumerable<ClientViewModel> Get(string name=null)
        {
            return repository.Get(filter:(c)=>name==null || c.Name.ToLower().Contains(name.ToLower())).Select(c=>Mapper.Map<ClientViewModel>(c));
        }

        // GET: api/Client/5
        public ClientViewModel Get(long id)
        {
            var client = repository.GetByID(id);
            return Mapper.Map<ClientViewModel>(client);
        }

        // POST: api/Client
        public ClientViewModel Post([FromBody]ClientViewModel value)
        {
            var client = Client.Create(
                value.Name,
                value.Address,
                value.Mobile,
                value.Email
                );
            repository.Insert(client);
            return Mapper.Map<ClientViewModel>(client);
        }

        // PUT: api/Client/5
        public ClientViewModel Put(long id, [FromBody]ClientViewModel value)
        {
            var client = repository.GetByID(value.Id);
            client.Update(
                value.Name,
                value.Address,
                value.Mobile,
                value.Email
                );
            repository.Update(client);
            return Mapper.Map<ClientViewModel>(client);
        }

        // DELETE: api/Client/5
        public void Delete(long id)
        {
            repository.Delete(id);
        }
    }
}
