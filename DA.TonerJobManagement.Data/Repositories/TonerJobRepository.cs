using DA.SharedKernel;
using DA.TonerJobManagement.Core.Aggregates.Models;
using DA.TonerJobManagement.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.TonerJobManagement.Data.Repositories
{
    public class TonerJobRepository : BaseRepository<TonerJob>
    {
        TonerJobContext context;
        public TonerJobRepository(TonerJobContext context):base(context)
        {
            this.context = context;
        }
    }
}
