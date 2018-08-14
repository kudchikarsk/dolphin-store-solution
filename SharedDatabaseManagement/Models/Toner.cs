using System.Collections.Generic;

namespace SharedDatabaseManagement.Models
{
    public class Toner
    {
        public long Id  { get ; set ; } 

        public virtual Model Model { get ; set ; } 
        public virtual Client Client { get; set; }
        public virtual IList<TonerJob> TonerJobs { get; set; }
    }
}