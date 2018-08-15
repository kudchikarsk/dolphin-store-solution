using DA.SharedKernel;
using DA.StockManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.StockManagement.Data.Repositories
{
    public class PartTypeRepository : BaseRepository<PartType>
    {
        public PartTypeRepository(StockContext context) : base(context)
        {

        }
    }
}
