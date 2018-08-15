using DA.SharedKernel;
using DA.SharedKernel.Interfaces;

namespace DA.StockManagement.Core.Models
{
    public class TonerPart : Entity<long>, IAggregateRoot
    {
        public string Name       { get ; private set ; } 
        public long   PartTypeId { get ; private set ; }  

        public TonerPart() //For Ef
        {

        }

        public void Update(
            string name,
            long partTypeId
            )
        {
            Guard.ForNullOrEmpty(name, "name");
            Guard.ForLessEqualZero(partTypeId, "tonerPartId");

            Name       = name       ; 
            PartTypeId = partTypeId ; 
        }

        private TonerPart(
            string name,
            long partTypeId
            )
        {
            Name       = name       ; 
            PartTypeId = partTypeId ;  
        }

        public static TonerPart Create(string name, long partTypeId)
        {
            Guard.ForNullOrEmpty(name, "name");
            Guard.ForLessEqualZero(partTypeId, "tonerPartId");

            return new TonerPart(name, partTypeId);
        }
    }
}