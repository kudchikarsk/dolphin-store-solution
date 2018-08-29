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
    public class EmployeeController : ApiController
    {
        private readonly IRepository<Employee> repository;

        public EmployeeController(IRepository<Employee> repository)
        {
            this.repository = repository;
        }

        // GET: api/Employee
        public IEnumerable<EmployeeViewModel> Get(string name = null)
        {
            return repository.Get(filter: (e) => name == null || e.Name.ToLower().Contains(name.ToLower())).Select(e => Mapper.Map<EmployeeViewModel>(e));
        }

        // GET: api/Employee/5
        public EmployeeViewModel Get(int id)
        {
            var employee = repository.GetByID(id);
            return Mapper.Map<EmployeeViewModel>(employee);
        }

        // POST: api/Employee
        public EmployeeViewModel Post([FromBody]EmployeeViewModel value)
        {
            var employee = Employee.Create(
                value.Name,
                value.Address,
                value.Mobile,
                value.Email
                );
            repository.Insert(employee);
            return Mapper.Map<EmployeeViewModel>(employee);
        }

        // PUT: api/Employee/5
        public EmployeeViewModel Put(long id, [FromBody]EmployeeViewModel value)
        {
            var employee = repository.GetByID(value.Id);
            employee.Update(
                value.Name,
                value.Address,
                value.Mobile,
                value.Email
                );
            repository.Update(employee);
            return Mapper.Map<EmployeeViewModel>(employee);
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
