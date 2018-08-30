using DA.TonerJobManagement.Core.Aggregates.Models;
using DA.TonerJobManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.TonerJobManagement.Data.Repositories
{
    public class PurchaseItemRepository : IPurchaseItemRepository
    {
        private readonly TonerJobContext context;
        private readonly DbSet<PurchaseItem> dbSet;

        public PurchaseItemRepository(TonerJobContext context)
        {
            this.context = context;
            this.dbSet = context.Set<PurchaseItem>();
        }

        public void Delete(PurchaseItem purchaseItem)
        {
            if (context.Entry(purchaseItem).State == EntityState.Detached)
            {
                dbSet.Attach(purchaseItem);
            }
            dbSet.Remove(purchaseItem);
            context.SaveChanges();
        }
    }
}
