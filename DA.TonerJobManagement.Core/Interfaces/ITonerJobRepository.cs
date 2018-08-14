using DA.TonerJobManagement.Core.Aggregates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.TonerJobManagement.Core.Interfaces
{
    public interface ITonerJobRepository
    {
        IEnumerable<TonerJob> Get(DateTime on);
    }
}
