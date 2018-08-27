using System;
using DA.SharedKernel;

namespace DA.TonerJobManagement.Core.Aggregates.Models
{
    public class StockItem:Entity<long>
    {
        public string Name { get ; private set ; } 
        public int  Quantity         { get ; private set ; } 
        public int  SellingPrice { get ; private set ; } 
        public int  CostPrice        { get ; private set ; }

        public StockItem() // For EF
        {

        }
    }
}