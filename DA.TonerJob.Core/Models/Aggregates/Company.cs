using DA.SharedKernel;
using System.Collections.Generic;

namespace DA.TonerJob.Core.Aggregates.Models
{
    public class Company : Entity<long>
    {
        public string Name { get ; set ; }       
    }
}