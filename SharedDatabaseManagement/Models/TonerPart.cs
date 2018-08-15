using System.Collections.Generic;

namespace SharedDatabaseManagement.Models
{
    public class TonerPart
    {

        public long Id   { get ; set ; } 
        public int  Name { get ; set ; } 

        public virtual PartType Type { get; set; }
        public virtual StockItem StockItem { get; set; }
    }
}