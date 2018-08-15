using DA.TonerJobManagement.Core.Aggregates.Models;
using DA.TonerJobManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.TonerJobManagement.Data.Repositories
{
    public class TonnerRepository : ITonnerRepository
    {
        private TonerJobContext context;

        public TonnerRepository(TonerJobContext tonerJobContext)
        {
            context = tonerJobContext;
        }

        public Toner GetTonnerByID(long id)
        {
            return context.Toners.Single(t => t.Id == id);
        }
    }
}
