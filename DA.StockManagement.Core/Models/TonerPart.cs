using DA.SharedKernel;
using DA.SharedKernel.Interfaces;

namespace DA.StockManagement.Core.Models
{
    public class TonerPart : Entity<long>, IAggregateRoot
    {
        public string Name       { get ; private set ; } 

        public TonerPart() //For Ef
        {

        }

        public void Update(
            string name
            )
        {
            Guard.ForNullOrEmpty(name, "name");

            Name       = name       ; 
        }

        private TonerPart(
            string name
            )
        {
            Name       = name       ;
        }

        public static TonerPart Create(string name)
        {
            Guard.ForNullOrEmpty(name, "name");

            return new TonerPart(name);
        }
    }
}