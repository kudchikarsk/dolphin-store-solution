using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedDatabaseManagement.Models
{
    public class StockItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int SellingPrice { get; set; }
        public int CostPrice { get; set; }  

        public virtual List<PurchaseItem> PurchaseItems { get; set; }
    }
}