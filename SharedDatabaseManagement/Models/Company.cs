using System.Collections.Generic;

namespace SharedDatabaseManagement.Models
{
    public class Company
    {
        public long   Id   { get ; set ; } 
        public string Name { get ; set ; } 

        public IList<Model> Models { get; set; }       
    }
}