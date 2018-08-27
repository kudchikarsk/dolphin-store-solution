using DA.SharedKernel.Interfaces;
using DA.StockManagement.Core.Models;
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
        private IRepository<StockItem> repository;

        public PurchasedItemsHandler(IRepository<StockItem> repository)
        {
            this.repository = repository;
        }

        public void Handle(PurchasedItemsEvent args)
        {
            foreach (var item in args.PurchaseItems)
            {
                var stockItem = repository.GetByID(item.StockItem.Id);
                stockItem.PurchasedQuantity(item.Quantity);
                repository.Update(stockItem);
            }
        }
    }
}