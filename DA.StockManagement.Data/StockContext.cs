using DA.StockManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.StockManagement.Data
{
    public class StockContext:DbContext 
    {
        public StockContext():base("name=DolphinContext")
        {
                    
        }

        public DbSet <StockItem> StockItems { get ; set ; } 
        public DbSet <TonerPart> TonerParts { get ; set ; } 
        public DbSet <PartType > PartTypes  { get ; set ; } 
    }
}
