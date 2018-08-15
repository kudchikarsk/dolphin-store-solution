using DA.StockManagement.Core.Models;
using DA.StockManagement.Data;
using DA.StockManagement.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrange
            var stockItem = StockItem.Create(10, 1, 1, 1);
            var repo = new StockItemRepository(new StockContext());

            //Act
            repo.Insert(stockItem);

        }
    }
}
