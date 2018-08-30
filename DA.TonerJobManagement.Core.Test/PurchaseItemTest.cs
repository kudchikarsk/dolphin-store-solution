using DA.TonerJobManagement.Core.Aggregates.Models;
using DA.TonerJobManagement.Data;
using DA.TonerJobManagement.Data.Repositories;
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
            var repo = new StockItemRepository(new TonerJobContext());
            //Act
            Action action = () => PurchaseItem.Create(repo.GetStockItemById(1), 2);

            //Assert
            action.Should().Throw<ArgumentException>().WithMessage("Quantity should be less than or equal to quantity in stock!");
        }
    }
}
