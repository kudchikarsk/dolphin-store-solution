using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedDatabaseManagement.Models
{
    public class Toner
    {
        public long Id  { get ; set ; }
        public string Name { get; set; }   
        public long ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public virtual List<TonerJob> TonerJobs { get; set; }
    }
}