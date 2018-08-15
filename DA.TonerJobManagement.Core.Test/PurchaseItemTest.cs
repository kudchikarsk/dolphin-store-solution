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
    public class PurchaseItemTest
    {
        [Fact]
        public void Purchase_Item_Quantity_Should_Be_Less_ThanEqual_To_Stock()
        {
            //Arrange
            //Act
            Action action = () => PurchaseItem.Create(new StockItem(1, 1, 1, 1), 2);

            //Assert
            action.Should().Throw<ArgumentException>().WithMessage("Quantity should be less than or equal to quantity in stock!");
        }
    }
}
