using DA.SharedKernel;

namespace DA.TonerJobManagement.Core.Aggregates.Models
{
    public class Toner : Entity<long>
    {
        public virtual Model Model { get; set; }
    }
}