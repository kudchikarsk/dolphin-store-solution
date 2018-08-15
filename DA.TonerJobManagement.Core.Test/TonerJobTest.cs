using DA.TonerJobManagement.Core.Aggregates.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DA.TonerJobManagement.Core.Test
{

    public class TonerJobTest
    {
        [Theory]
        [ InlineData ( 0 , 1 , 1 , "2018-01-01" , "2018-01-02" , "Remarks" , 0 , 1 ) ] 
        [ InlineData ( 1 , 0 , 1 , "2018-01-01" , "2018-01-02" , "Remarks" , 0 , 2 ) ] 
        [ InlineData ( 1 , 1 , 0 , "2018-01-01" , "2018-01-02" , "Remarks" , 0 , 3 ) ] 
        [ InlineData ( 1 , 1 , 1 , "2018-01-02" , "2018-01-01" , "Remarks" , 0 , 4 ) ] 
        [ InlineData ( 1 , 1 , 1 , "2018-01-01" , "2018-01-02" , "Remarks" , 0 , 5 ) ]  
        [ InlineData ( 1 , 1 , 1 , "2018-01-01" , "2018-01-02" , "Remarks" , 0 , 6 ) ]  
        public void TonerJob_Should_Throws_Error_On_Invalid_Params(
            long clientId,
            long collectedById,
            long deliveredById,
            string @in,
            string @out,
            string remarks,
            int otherCharges,
            int index
            )
        {
            //Arrange
            var inDate = @in.Split('-').Select(s=>Int32.Parse(s)).ToArray();
            var outDate = @out.Split('-').Select(s => Int32.Parse(s)).ToArray();
            var stockItems = new List<PurchaseItem>();
            var toners = new List<Toner>();
            if (index == 5)
                stockItems = null;
            if (index == 6)
                toners = null;

            //Act
            Action action = () => TonerJob.Create(
                clientId, 
                toners,
                collectedById,
                deliveredById, 
                new DateTime(inDate[0], inDate[1], inDate[2]), 
                new DateTime(outDate[0], outDate[1], outDate[2]), 
                stockItems,
                remarks, 
                otherCharges);

            //Assert
            action.Should().Throw<ArgumentException>();
    
        }

        [Theory]        
        [InlineData(1, 1, 1, 1, "2018-01-01", "2018-01-02", "Remarks", 0, 5)]
        public void TonerJob_Should_Not_Throws_Error_On_Invalid_Params(
            long clientId,
            long tonnerId,
            long collectedById,
            long deliveredById,
            string @in,
            string @out,
            string remarks,
            int otherCharges,
            int index
            )
        {
            //Arrange
            var inDate = @in.Split('-').Select(s => Int32.Parse(s)).ToArray();
            var outDate = @out.Split('-').Select(s => Int32.Parse(s)).ToArray();
            var stockItems = new List<PurchaseItem>();

            //Act
            Action action = () => TonerJob.Create(
                clientId,
                new List<Toner>(),
                collectedById,
                deliveredById,
                new DateTime(inDate[0], inDate[1], inDate[2]),
                new DateTime(outDate[0], outDate[1], outDate[2]),
                stockItems,
                remarks,
                otherCharges);

            //Assert
            action.Should().NotThrow<Exception>();

        }
    }
}
