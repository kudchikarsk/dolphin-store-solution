using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedDatabaseManagement.Models
{
    public class TonerJob
    {
        public long   Id            { get ; set ; } 
        public long   ClientId      { get ; set ; } 
        public long   CollectedById { get ; set ; } 
        public long   DeliveredById { get ; set ; } 
        public string Remarks       { get ; set ; } 
        public int    OtherCharges  { get ; set ; } 
        public double Discount      { get ; set ; }  

        public DateTime In            { get ; set ; } 
        public DateTime Out           { get ; set ; } 
        public DateTime Modified      { get ; set ; } 
        public DateTime Created       { get ; set ; }

        public virtual Client Client { get; set; }
        [ForeignKey("CollectedById")]
        public virtual Employee CollectedBy { get; set; }
        [ForeignKey("DeliveredById")]
        public virtual Employee DeliveredBy { get; set; }
        public virtual List<Toner> Toners { get; set; }
        public virtual List<PurchaseItem> PurchaseItems { get; set; }
    }
}
