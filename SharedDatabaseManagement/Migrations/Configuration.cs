namespace SharedDatabaseManagement.Migrations
{
    using SharedDatabaseManagement.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SharedDatabaseManagement.DataModel.DolphinContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SharedDatabaseManagement.DataModel.DolphinContext context)
        {
            var client = new Client()
            {
                Id      = 1                   , 
                Name    = "Doctor Strange"    , 
                Address = "New York"          , 
                Mobile  = "99999999999"       , 
                Email   = "strange@gmail.com" ,   
            };

            var toner = new Toner()
            {
                Id     = 1            , 
                Name   = "Epson L800" , 
                Client = client       , 
            };

            var employee = new Employee()
            {
                Id      = 1                  , 
                Name    = "SpiderMan"        , 
                Address = "New York"         , 
                Mobile  = "99999999999"      , 
                Email   = "spider@gmail.com" , 
            };

            context.Clients.AddOrUpdate(client);
            context.Toners.AddOrUpdate(toner);
            context.Employees.AddOrUpdate(employee);
        }
    }
}
