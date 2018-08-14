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
           
        }
    }
}
