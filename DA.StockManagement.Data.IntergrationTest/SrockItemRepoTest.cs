﻿using System;
using DA.StockManagement.Core.Models;
using DA.StockManagement.Data.Repositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace DA.StockManagement.Data.IntergrationTest
{
    public class SrockItemRepoTest
    {
        public void New_StockItem_Should_Get_Inserted_Without_Error()
        {
            //Arrange
            var stockItem = StockItem.Create(10,1,1,1);
            var repo = new StockItemRepository(new StockContext());

            //Act
            Action action = () => repo.Insert(stockItem);

            //Assert
            action.Should().NotThrow<Exception>();
        }
    }
}
