using DA.SharedKernel;
using System.Collections.Generic;

namespace DA.TonerJobManagement.Core.Aggregates.Models
{
    public class Company : Entity<long>
    {
        public string Name { get ; set ; }       
    }
}