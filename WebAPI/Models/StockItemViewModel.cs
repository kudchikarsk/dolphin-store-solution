using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class StockItemViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int SellingPrice { get; set; }
        public int CostPrice { get; set; }
    }
}