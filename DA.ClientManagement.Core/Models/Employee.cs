using DA.SharedKernel;
using DA.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.ClientManagement.Core.Models
{
    public class Employee : Entity<long>, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Mobile { get; private set; }
        public string Email { get; private set; }

        public Employee() //For EF
        {

        }

        public void Update(
            string name,
            string address,
            string mobile,
            string email
            )
        {
            Guard.ForNullOrEmpty(name, "name");
            Guard.ForEmail(email, "email");
            Guard.ForPhoneNumber(mobile, "mobile");

            Name = name;
            Address = address;
            Mobile = mobile;
            Email = email;
        }

        private Employee(
            string name,
            string address,
            string mobile,
            string email
            )
        {
            Name = name;
            Address = address;
            Mobile = mobile;
            Email = email;
        }

        public static Employee Create(
            string name,
            string address,
            string mobile,
            string email
            )
        {

            Guard.ForNullOrEmpty(name, "name");
            Guard.ForEmail(email, "email");
            Guard.ForPhoneNumber(mobile, "mobile");

            return new Employee(
                name,
                address,
                mobile,
                email
                );
        }
    }
}
