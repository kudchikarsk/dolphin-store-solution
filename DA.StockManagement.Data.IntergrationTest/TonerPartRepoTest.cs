using DA.StockManagement.Core.Models;
using DA.StockManagement.Data.Repositories;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DA.StockManagement.Data.IntergrationTest
{
    public class TonerPartRepoTest
    {
        public void New_TonerPart_Should_Get_Inserted_Without_Error()
        {
            //Arrange
            var tonerPart = TonerPart.Create("Epson L800", 1);
            var repo = new TonerPartRepository(new StockContext());

            //Act
            Action action = () => repo.Insert(tonerPart);

            //Assert
            action.Should().NotThrow<Exception>();
        }
    }
}
