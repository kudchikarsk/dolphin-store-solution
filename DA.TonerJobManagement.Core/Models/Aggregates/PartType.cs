using DA.SharedKernel;

namespace DA.TonerJobManagement.Core.Aggregates.Models
{
    public class PartType : Entity<long>
    {
        public string Name { get; set; }
    }
}