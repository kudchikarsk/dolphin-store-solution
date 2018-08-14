using System.Collections.Generic;

namespace SharedDatabaseManagement.Models
{
    public class TonerPart
    {

        public long Id         { get ; set ; } 
        public int  PurchaseAt { get ; set ; } 
        public int  SoldAt     { get ; set ; } 

        public virtual Model Model { get; set; }
        public virtual PartType Type { get; set; }
        public virtual IList<TonerJob> TonerJobs { get; set; }
        public virtual Stock Stock { get; set; }
    }
}