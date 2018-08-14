using System.Collections.Generic;

namespace SharedDatabaseManagement.Models
{
    public class Employee
    {
        public long   Id      { get ; set ; } 
        public int    Name    { get ; set ; } 
        public string Address { get ; set ; } 
        public int    Mobile  { get ; set ; } 
        public string Email   { get ; set ; }

        public virtual IList<TonerJob> CollectedToners { get; set; }
        public virtual IList<TonerJob> DeliveredToners { get; set; }
    }
}