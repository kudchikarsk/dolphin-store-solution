using DA.SharedKernel;

namespace DA.TonerJob.Core.Aggregates.Models
{
    public class Client : Entity<long>
    {
        public int Name { get; set; }
        public string Address { get; set; }
        public int Mobile { get; set; }
        public string Email { get; set; }
    }
}