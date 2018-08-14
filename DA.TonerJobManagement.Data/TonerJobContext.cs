using DA.TonerJobManagement.Core.Aggregates.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.TonerJobManagement.Data
{
    public class TonerJobContext : DbContext
    {
        public TonerJobContext() : base("name=DolphinContext")
        {
            Database.SetInitializer<TonerJobContext>(null);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<PartType> PartTypes { get; set; }
        public DbSet<Toner> Toners { get; set; }
        public DbSet<TonerJob> TonerJobs { get; set; }
        public DbSet<TonerPart> TonerParts { get; set; }
    }
}
