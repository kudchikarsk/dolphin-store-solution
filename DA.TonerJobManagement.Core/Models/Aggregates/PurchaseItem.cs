using DA.SharedKernel;
using System;

namespace DA.TonerJobManagement.Core.Aggregates.Models
{
    public class PurchaseItem:Entity<long>
    {
        public int Quantity { get ; private set ; } 

        public StockItem StockItem { get ; private set ; } 
        public TonerJob  TonerJob  { get ; private set ; }

        public PurchaseItem() //For EF
        {

        }

        public void UpdateQuantity(int quantity)
        {
            if (quantity > StockItem.Quantity)
            {
                throw new ArgumentException("Quantity should be less than or equal to quantity in stock!");
            }

            Quantity = quantity;
        }

        private PurchaseItem(StockItem stockItem, int quantity)
        {
            StockItem = stockItem;
            Quantity = quantity;
        }

        public static PurchaseItem Create(StockItem stockItem, int quantity)
        {
            Guard.ForNull(stockItem, "stockItem");
            Guard.ForLessEqualZero(quantity, "quantity");

            var item = new PurchaseItem(stockItem,0);
            item.UpdateQuantity(quantity);

            return item;
        }
    }
}