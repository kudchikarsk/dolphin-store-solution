using DA.TonerJobManagement.Core.Aggregates.Models;
using DA.TonerJobManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.TonerJobManagement.Data.Repositories
{
    public class StockItemRepository : IStockItemRepository
    {
        private readonly TonerJobContext context;

        public StockItemRepository(TonerJobContext context)
        {
            this.context = context;
        }

        public StockItem GetStockItemById(long id)
        {
            return context.StockItems.Single(t => t.Id == id);
        }
    }
}
