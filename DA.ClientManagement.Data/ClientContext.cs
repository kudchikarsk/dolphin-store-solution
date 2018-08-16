using DA.ClientManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.ClientManagement.Data
{
    public class ClientContext:DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Toner> Toners { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ClientContext() : base("name=DolphinContext")
        {

        }
    }
}
