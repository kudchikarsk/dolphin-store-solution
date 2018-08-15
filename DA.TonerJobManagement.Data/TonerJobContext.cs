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
        }

        public DbSet<Toner> Toners { get; set; }
        public DbSet<TonerJob> TonerJobs { get; set; }
    }
}
