using System.Collections.Generic;

namespace SharedDatabaseManagement.Models
{
    public class Model
    {
        public long   Id   { get ; set ; } 
        public string Name { get ; set ; } 

        public virtual Company Company { get; set; }
        public IList<Toner> Toners { get; set; }
        public IList<TonerPart> TonerParts { get; set; }
    }
}