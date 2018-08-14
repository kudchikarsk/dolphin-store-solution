using DA.SharedKernel;

namespace DA.TonerJob.Core.Aggregates.Models
{
    public class TonerPart : Entity<long>
    {
        public int PurchaseAt { get; set; }
        public int SoldAt { get; set; }

        public virtual Model Model { get; set; }
        public virtual PartType Type { get; set; }
    }
}