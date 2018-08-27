using System;
using DA.SharedKernel.Interfaces;
using DA.TonerJobManagement.Core.Aggregates.Models;

namespace DA.TonerJobManagement.Core.Models.Events
{
    public class ReturnedItemsEvent:IDomainEvent
    {
        private PurchaseItem[] returnedItems;
        private DateTime dateTime;

        public ReturnedItemsEvent(DateTime dateTime, params PurchaseItem[] returnedItems)
        {
            this.returnedItems = returnedItems;
            this.dateTime = dateTime;
        }

        public DateTime DateTimeEventOccurred => dateTime;
        public PurchaseItem[] ReturnedItems => returnedItems;
    }
}