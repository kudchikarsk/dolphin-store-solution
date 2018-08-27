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
    public class ReturnedItemsHandler : IHandle<ReturnedItemsEvent>
    {
        public void Handle(ReturnedItemsEvent args)
        {
            var repo = new StockItemRepository(new StockContext());
            foreach (var item in args.ReturnedItems)
            {
                var stockItem = repo.GetByID(item.StockItem.Id);
                stockItem.ReturnedQuantity(item.Quantity);
                repo.Update(stockItem);
            }
        }
    }
}