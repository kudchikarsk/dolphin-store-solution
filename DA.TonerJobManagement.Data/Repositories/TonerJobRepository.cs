using DA.TonerJobManagement.Core.Aggregates.Models;
using DA.TonerJobManagement.Core.Interfaces;
using DA.TonerJobManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.TonerJobManagement.Data.Repositories
{
    public class TonerJobRepository : ITonerJobRepository
    {
        private TonerJobContext tonerJobContext;

        public TonerJobRepository(TonerJobContext tonerJobContext)
        {
            this.tonerJobContext= tonerJobContext;
        }

        public IEnumerable<TonerJobManagement.Core.Aggregates.Models.TonerJob> Get(DateTime on)
        {
            throw new NotImplementedException();
        }
    }
}
