using DA.SharedKernel;
using DA.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.ClientManagement.Core.Models
{
    public class Toner : Entity<long>, IAggregateRoot
    {
        public string Name     { get ; private set ; } 
        public long   ClientId { get ; private set ; }

        public Toner() //For EF
        {

        }

        public void Update(
            string name,
            long clientId
            )
        {
            Guard.ForNullOrEmpty(name, "name");
            Guard.ForLessEqualZero(clientId, "clientId");

            Name = name;
            ClientId = clientId;
        }

        private Toner(
            string name,
            long clientId
            )
        {
            Name = name;
            ClientId = clientId;
        }

        public static Toner Create(
            string name,
            long clientId
            )
        {
            Guard.ForNullOrEmpty(name, "name");
            Guard.ForLessEqualZero(clientId, "clientId");

            return new Toner(name,clientId);
        }
    }
}
