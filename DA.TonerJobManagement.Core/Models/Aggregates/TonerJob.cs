using DA.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.TonerJobManagement.Core.Aggregates.Models
{
    public class TonerJob : Entity<long>
    {
        public long             ClientId        { get; private set; }
        public long             CollectedById   { get; private set; }
        public long             DeliveredById   { get; private set; }        
        public string           Remarks         { get; private set; }
        public int              OtherCharges    { get; private set; }
        public double           Discount        { get; private set; }

        public DateTime Modified { get ; private set ; } 
        public DateTime Created  { get ; private set ; } 
        public DateTime In       { get ; private set ; } 
        public DateTime Out      { get ; private set ; } 

        public virtual List<Toner> Toners { get; private set; }
        public virtual List<TonerPart> TonerParts { get; private set; }

        public TonerJob() //For EF
        {

        }

        private TonerJob(
            long             clientId        ,
            long             collectedById   ,
            long             deliveredById   ,
            DateTime         @in             ,
            DateTime         @out            ,
            List<Toner>      toners          ,
            List<TonerPart>  tonerParts      ,
            string           remarks         ,
            int              otherCharges    ,
            DateTime         created         ,
            DateTime         modified        
            )
        {
            ClientId        =   clientId        ;
            CollectedById   =   collectedById   ;
            DeliveredById   =   deliveredById   ;
            In              =   @in             ;
            Out             =   @out            ;
            Toners          =   toners          ;
            TonerParts      =   tonerParts      ;
            Remarks         =   remarks         ;
            OtherCharges    =   otherCharges    ;
            Created         =   created         ;
            Modified        =   modified        ;

        }

        public int GrossTotal => TonerParts.Sum(t => t.SoldAt) + OtherCharges;
        public int NetTotal => (int) Math.Ceiling(GrossTotal - (Discount * GrossTotal));

        public void UpdateTonerParts(IEnumerable<TonerPart> tonerParts)
        {
            var revertParts = TonerParts.ToList();
            TonerParts.Clear();

            TonerParts.AddRange(tonerParts);            

            Modified = DateTime.Now;

            //Raise revert parts event
            //use revertParts within event

            //Raise parts replaced event
            //use tonerParts within event
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
            long             clientId        ,
            long             collectedById   ,
            long             deliveredById   ,
            DateTime         @in             ,
            DateTime         @out            ,
            List<Toner>      toners          ,
            List<TonerPart>  tonerParts      ,
            string           remarks         ,
            int              otherCharges    
            )
        {

            Guard.ForLessEqualZero(clientId, "clientId");
            Guard.ForLessEqualZero(collectedById, "collectedById");
            Guard.ForLessEqualZero(deliveredById, "deliveredById");
            if (@out < @in) throw new ArgumentException("In time should be less than Out time!");

            return new TonerJob(
                clientId        ,
                collectedById   ,
                deliveredById   ,
                @in             ,
                @out            ,
                toners          ,
                tonerParts      ,
                remarks         ,
                otherCharges    ,
                DateTime.Now    ,
                DateTime.Now
                );
        }
    }
}
