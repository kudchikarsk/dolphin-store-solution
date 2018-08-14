using System.Collections.Generic;

namespace SharedDatabaseManagement.Models
{
    public class Client
    {
        public long   Id      { get ; set ; } 
        public int    Name    { get ; set ; } 
        public string Address { get ; set ; } 
        public int    Mobile  { get ; set ; } 
        public string Email   { get ; set ; }   

        public virtual IList<Toner> Toners { get; set; }
        public virtual IList<TonerJob> TonerJobs { get; set; }
    }
}