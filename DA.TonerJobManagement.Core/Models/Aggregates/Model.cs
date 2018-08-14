using DA.SharedKernel;
using System.Collections.Generic;

namespace DA.TonerJobManagement.Core.Aggregates.Models
{
    public class Model : Entity<long>
    {
        public long   Id   { get ; set ; } 
        public string Name { get ; set ; } 

        public virtual Company Company { get; set; }
    }
}