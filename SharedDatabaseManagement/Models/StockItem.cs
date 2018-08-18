using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedDatabaseManagement.Models
{
    public class StockItem
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public int SellingPrice { get; set; }
        public int CostPrice { get; set; }        
        public long TonerPartId { get; set; }

        [ForeignKey("TonerPartId")]
        public virtual TonerPart TonerPart { get; set; }
        public virtual List<PurchaseItem> PurchaseItems { get; set; }
    }
}