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
        public int  UnitSellingPrice { get ; private set ; } 
        public int  UnitPrice         { get ; private set ; } 
        public long TonerPartId       { get ; private set ; }  

        public StockItem() //For Ef
        {

        }

        public void Update(
            int quantity,
            int unitSellingPrice,
            int unitPrice,
            long tonerPartId
            )
        {
            Guard.ForLessEqualZero(tonerPartId, "tonerPartId");
            Guard.ForLessEqualZero(unitSellingPrice, "unitSelllingPrice");

            Quantity = quantity;
            UnitSellingPrice = unitSellingPrice;
            UnitPrice = unitPrice;
            TonerPartId = tonerPartId;
        }

        private StockItem(
            int quantity,
            int unitSellingPrice,
            int unitPrice,
            long tonerPartId     
            )
        {
            Quantity         = quantity         ; 
            UnitSellingPrice = unitSellingPrice ; 
            UnitPrice        = unitPrice        ; 
            TonerPartId      = tonerPartId      ; 
        }

        public static StockItem Create(
            int  quantity,
            int  unitSellingPrice,
            int  unitPrice,
            long tonerPartId
            )
        {
            Guard.ForLessEqualZero(tonerPartId, "tonerPartId");
            Guard.ForLessEqualZero(unitSellingPrice, "unitSelllingPrice");

            return new StockItem(
                quantity,
                unitSellingPrice,
                unitPrice,
                tonerPartId
                );
        }
    }
}
