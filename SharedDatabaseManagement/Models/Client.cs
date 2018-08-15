using System.Collections.Generic;

namespace SharedDatabaseManagement.Models
{
    public class Client
    {
        public long   Id      { get ; set ; } 
        public string    Name    { get ; set ; } 
        public string Address { get ; set ; } 
        public string    Mobile  { get ; set ; } 
        public string Email   { get ; set ; }   

        public virtual List<Toner> Toners { get; set; }
        public virtual List<TonerJob> TonerJobs { get; set; }
    }
}