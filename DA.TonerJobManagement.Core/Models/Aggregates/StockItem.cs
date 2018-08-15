using DA.SharedKernel;

namespace DA.TonerJobManagement.Core.Aggregates.Models
{
    public class StockItem:Entity<long>
    {
        public long TonerPartId      { get ; private set ; } 
        public int  Quantity         { get ; private set ; } 
        public int  UnitSellingPrice { get ; private set ; } 
        public int  UnitPrice        { get ; private set ; }

        public StockItem() // For EF
        {

        }

        public StockItem(
            long tonerPartId      ,
            int  quantity         ,
            int  unitSellingPrice ,
            int  unitPrice        
            )
        {
            TonerPartId      = tonerPartId      ;
            Quantity         = quantity         ;
            UnitSellingPrice = unitSellingPrice ;
            UnitPrice        = unitPrice        ;
        }
    }
}