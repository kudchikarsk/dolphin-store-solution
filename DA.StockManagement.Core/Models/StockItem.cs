using DA.SharedKernel;
using DA.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.StockManagement.Core.Models
{
    public class StockItem : Entity<long>, IAggregateRoot
    {
        public string Name { get; set; }
        public int  Quantity          { get ; private set ; } 
        public int  SellingPrice { get ; private set ; } 
        public int  CostPrice         { get ; private set ; } 

        public StockItem() //For Ef
        {

        }

        public void Update(
            string name,
            int quantity,
            int sellingPrice,
            int costPrice
            )
        {
            Guard.ForNullOrEmpty(name, "name");
            Guard.ForLessEqualZero(sellingPrice, "sellingPrice");

            Name = name;
            Quantity = quantity;
            SellingPrice = sellingPrice;
            CostPrice = costPrice;
        }

        public void ReturnedQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void PurchasedQuantity(int quantity)
        {
            Quantity -= quantity;
        }

        private StockItem(
            string name,
            int quantity,
            int sellingPrice,
            int costPrice
            )
        {
            Name         = name         ; 
            Quantity     = quantity     ; 
            SellingPrice = sellingPrice ; 
            CostPrice    = costPrice    ; 
        }

        public static StockItem Create(
            string name,
            int  quantity,
            int  sellingPrice,
            int  costPrice
            )
        {
            Guard.ForNullOrEmpty(name, "name");
            Guard.ForLessEqualZero(sellingPrice, "sellingPrice");

            return new StockItem(
                name,
                quantity,
                sellingPrice,
                costPrice
                );
        }
    }
}
