using DA.SharedKernel;
using DA.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.TonerJobManagement.Core.Aggregates.Models
{
    public class TonerJob : Entity<long>, IAggregateRoot
    {
        public long   ClientId      { get ; private set ; } 
        public long   CollectedById { get ; private set ; } 
        public long   DeliveredById { get ; private set ; } 
        public string Remarks       { get ; private set ; } 
        public int    OtherCharges  { get ; private set ; } 
        public double Discount      { get ; private set ; } 

        public DateTime Modified { get ; private set ; } 
        public DateTime Created  { get ; private set ; } 
        public DateTime In       { get ; private set ; } 
        public DateTime Out      { get ; private set ; } 
        public virtual List<PurchaseItem> PurchasedItems { get; private set; }
        public virtual List<Toner> Toners { get; private set; }

        public TonerJob() //For EF
        {

        }

        private TonerJob(
            long                clientId        ,
            List<Toner>         toners          ,
            long                collectedById   ,
            long                deliveredById   ,
            DateTime            @in             ,
            DateTime            @out            ,            
            List<PurchaseItem>  purchaseItems   ,
            string              remarks         ,
            int                 otherCharges    ,
            DateTime            created         ,
            DateTime            modified        
            )
        {
            ClientId        = clientId      ; 
            CollectedById   = collectedById ; 
            DeliveredById   = deliveredById ; 
            In              = @in           ; 
            Out             = @out          ; 
            Toners          = toners        ;
            PurchasedItems  = purchaseItems ; 
            Remarks         = remarks       ; 
            OtherCharges    = otherCharges  ; 
            Created         = created       ; 
            Modified        = modified      ; 

        }

        public int GrossTotal => PurchasedItems.Sum(s => s.StockItem.UnitSellingPrice * s.StockItem.Quantity) + OtherCharges;
        public int NetTotal => (int) Math.Ceiling(GrossTotal - (Discount * GrossTotal));

        public void UpdatePurchaseItems(IEnumerable<PurchaseItem> purchasedItems)
        {
            var returnedItems = PurchasedItems.ToList();
            PurchasedItems.Clear();

            PurchasedItems.AddRange(purchasedItems);            

            Modified = DateTime.Now;

            //TODO Raise returned PurchaseItems event
            //use returnPurchaseItems within event

            //TODO Raise bought PurchasedItems event
            //use purchasedItems within event
        }

        public void ReturnPurchaseItems()
        {
            var returnedItems = PurchasedItems.ToList();
            PurchasedItems.Clear();

            //TODO Raise returned PurchaseItems event
            //use returnPurchaseItems within event
        }

        public void UpdateIn(DateTime at)
        {
            if (at > Out) throw new ArgumentException("In time should be less than Out time!");
            In = at;

            Modified = DateTime.Now;
        }

        public void UpdateOut(DateTime at)
        {
            if (at < In) throw new ArgumentException("In time should be less than Out time!");
            Out = at;

            Modified = DateTime.Now;
        }

        public void UpdateAmount(int target)
        {
            var diff = target - GrossTotal;
            if (target < 0)
                Discount = Math.Abs(diff) / (long)GrossTotal;
            else
                OtherCharges = diff;

            Modified = DateTime.Now;
        }

        public static TonerJob Create(
            long                clientId        ,
            List<Toner>         toners          ,
            long                collectedById   ,
            long                deliveredById   ,
            DateTime            @in             ,
            DateTime            @out            ,
            List<PurchaseItem>  purchaseItems   ,
            string              remarks         ,
            int                 otherCharges    
            )
        {

            Guard.ForLessEqualZero(clientId, "clientId");
            Guard.ForLessEqualZero(collectedById, "collectedById");
            Guard.ForLessEqualZero(deliveredById, "deliveredById");
            Guard.ForNull(purchaseItems, "purchaseItems");
            Guard.ForNull(toners, "toners");

            if (@out < @in) throw new ArgumentException("In time should be less than Out time!");

            return new TonerJob(
                clientId        ,
                toners          ,
                collectedById   ,
                deliveredById   ,
                @in             ,
                @out            ,
                purchaseItems   ,
                remarks         ,
                otherCharges    ,
                DateTime.Now    ,
                DateTime.Now
                );
        }
    }
}
