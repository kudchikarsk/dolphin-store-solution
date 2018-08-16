using SharedDatabaseManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDatabaseManagement.DataModel
{
    class DolphinContext:DbContext
    {
        public DolphinContext():base("DolphinContext")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PartType> PartTypes { get; set; }
        public DbSet<Toner> Toners { get; set; }
        public DbSet<TonerJob> TonerJobs { get; set; }
        public DbSet<TonerPart> TonerParts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TonerJob>()
                        .HasRequired(m => m.CollectedBy)
                        .WithMany(t => t.CollectedToners)
                        .HasForeignKey(m => m.CollectedById)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<TonerJob>()
                        .HasRequired(m => m.DeliveredBy)
                        .WithMany(t => t.DeliveredToners)
                        .HasForeignKey(m => m.DeliveredById)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Toner>()
                        .HasRequired(t => t.Client)
                        .WithMany(c=>c.Toners)
                        .HasForeignKey(t=>t.ClientId)
                        .WillCascadeOnDelete(false);
        }
    }
}
