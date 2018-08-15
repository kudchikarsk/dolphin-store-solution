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
    public class PartTypeRepoTest
    {
        public void New_PartType_Should_Get_Inserted_Without_Error()
        {
            //Arrange
            var partType = PartType.Create("Roller");
            var repo = new PartTypeRepository(new StockContext());

            //Act
            Action action = () => repo.Insert(partType);

            //Assert
            action.Should().NotThrow<Exception>();
        }


    }
}
