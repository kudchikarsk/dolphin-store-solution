using DA.SharedKernel.Interfaces;
using DA.TonerJobManagement.Core.Aggregates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.TonerJobManagement.Core.Models.Events
{
    public class PurchasedItemsEvent : IDomainEvent
    {
        private readonly PurchaseItem[] purchaseItems;
        private DateTime dateTime;

        public PurchasedItemsEvent(DateTime dateTime, params PurchaseItem[] purchaseItems)
        {
            this.purchaseItems = purchaseItems;
            this.dateTime = dateTime;
        }

        public DateTime DateTimeEventOccurred => dateTime;
        public PurchaseItem[] PurchaseItems => purchaseItems;
    }
}
