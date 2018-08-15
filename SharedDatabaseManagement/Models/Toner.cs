using System.Collections.Generic;

namespace SharedDatabaseManagement.Models
{
    public class Toner
    {
        public long Id  { get ; set ; }
        public string Name { get; set; }

        public virtual Client Client { get; set; }
        public virtual List<TonerJob> TonerJobs { get; set; }
    }
}