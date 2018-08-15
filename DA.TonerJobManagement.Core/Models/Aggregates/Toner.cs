using DA.SharedKernel;
using System.Collections.Generic;

namespace DA.TonerJobManagement.Core.Aggregates.Models
{
    public class Toner : Entity<long>
    {
        public string Name { get; private set; }
        public List<TonerJob> TonerJobs { get; private set; }
    }
}