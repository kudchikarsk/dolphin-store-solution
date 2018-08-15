﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedDatabaseManagement.Models
{
    public class StockItem
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public int UnitSellingPrice { get; set; }
        public int UnitPrice { get; set; }
        [ForeignKey("TonerPart")]
        public long TonerPartId { get; set; }
        public virtual TonerPart TonerPart { get; set; }
        public virtual List<PurchaseItem> PurchaseItems { get; set; }
    }
}