using DA.SharedKernel;
using DA.SharedKernel.Interfaces;

namespace DA.StockManagement.Core.Models
{
    public class PartType : Entity<long>, IAggregateRoot
    {
        public string Name { get; private set; }

        public PartType() //For EF
        {                
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        private PartType(string name)
        {
            Name = name;
        }
        
        public static PartType Create(string name)
        {
            Guard.ForNullOrEmpty(name, "name");
            return new PartType(name);
        }
    }
}