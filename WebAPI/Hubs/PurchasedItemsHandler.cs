using DA.SharedKernel.Interfaces;
using DA.StockManagement.Data;
using DA.StockManagement.Data.Repositories;
using DA.TonerJobManagement.Core.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Hubs
{
    public class PurchasedItemsHandler : IHandle<PurchasedItemsEvent>
    {
        public void Handle(PurchasedItemsEvent args)
        {
            var repo = new StockItemRepository(new StockContext());
            foreach (var item in args.PurchaseItems)
            {
                var stockItem = repo.GetByID(item.StockItem.Id);
                stockItem.PurchasedQuantity(item.Quantity);
                repo.Update(stockItem);
            }
        }
    }
}