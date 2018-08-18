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
        public int  Quantity          { get ; private set ; } 
        public int  SellingPrice { get ; private set ; } 
        public int  CostPrice         { get ; private set ; } 
        public long TonerPartId       { get ; private set ; }  

        public StockItem() //For Ef
        {

        }

        public void Update(
            int quantity,
            int sellingPrice,
            int costPrice,
            long tonerPartId
            )
        {
            Guard.ForLessEqualZero(tonerPartId, "tonerPartId");
            Guard.ForLessEqualZero(sellingPrice, "sellingPrice");

            Quantity = quantity;
            SellingPrice = sellingPrice;
            CostPrice = costPrice;
            TonerPartId = tonerPartId;
        }

        private StockItem(
            int quantity,
            int sellingPrice,
            int costPrice,
            long tonerPartId     
            )
        {
            Quantity     = quantity     ; 
            SellingPrice = sellingPrice ; 
            CostPrice    = costPrice    ; 
            TonerPartId  = tonerPartId  ;  
        }

        public static StockItem Create(
            int  quantity,
            int  sellingPrice,
            int  costPrice,
            long tonerPartId
            )
        {
            Guard.ForLessEqualZero(tonerPartId, "tonerPartId");
            Guard.ForLessEqualZero(sellingPrice, "sellingPrice");

            return new StockItem(
                quantity,
                sellingPrice,
                costPrice,
                tonerPartId
                );
        }
    }
}
