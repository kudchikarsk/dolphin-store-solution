namespace WebAPI.Models
{
    public class PurchaseItemViewModel
    {
        public int Quantity { get; set; }
        public StockItemViewModel StockItem { get; set; }
    }
}