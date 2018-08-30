using System.ComponentModel.DataAnnotations.Schema;

namespace SharedDatabaseManagement.Models
{
    public class PurchaseItem
    {
        public long Id { get; set; }
        public int Quantity { get; set; }

        public virtual StockItem StockItem { get; set; }
        public virtual TonerJob TonerJob { get; set; }
    }
}