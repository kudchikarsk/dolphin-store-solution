using DA.SharedKernel;

namespace DA.TonerJob.Core.Aggregates.Models
{
    public class PartType : Entity<long>
    {
        public string Name { get; set; }
    }
}