using DA.TonerJobManagement.Core.Aggregates.Models;
using DA.TonerJobManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.TonerJobManagement.Data.Repositories
{
    public class TonerRepository : ITonerRepository
    {
        private TonerJobContext context;

        public TonerRepository(TonerJobContext tonerJobContext)
        {
            context = tonerJobContext;
        }

        public Toner GetTonerById(long id)
        {
            return context.Toners.Single(t => t.Id == id);
        }
    }
}
