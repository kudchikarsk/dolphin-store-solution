using DA.ClientManagement.Core.Models;
using DA.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.ClientManagement.Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(ClientContext context):base(context)
        {

        }
    }
}
