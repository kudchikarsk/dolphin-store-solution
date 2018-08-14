using System.Collections.Generic;

namespace SharedDatabaseManagement.Models
{
    public class PartType
    {
        public long   Id   { get ; set ; } 
        public string Name { get ; set ; } 

        public virtual IList<TonerPart> TonerParts { get; set; }
    }
}