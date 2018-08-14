using DA.SharedKernel;

namespace DA.TonerJob.Core.Aggregates.Models
{
    public class Toner : Entity<long>
    {
        public virtual Model Model { get; set; }
    }
}