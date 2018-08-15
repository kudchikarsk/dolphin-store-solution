using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedDatabaseManagement.Models
{
    public class TonerPart
    {

        public long Id   { get ; set ; } 
        public string  Name { get ; set ; } 
        [ForeignKey("PartType")]
        public long PartTypeId { get; set; }
        public virtual PartType PartType { get; set; }
    }
}