namespace eStoreServices.Migrations
{
    using eStoreServices.Models;
        using System.IO;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eStoreServices.Models.eStoreServicesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(eStoreServices.Models.eStoreServicesContext context)
        {
            context.Patterns.AddOrUpdate(x => x.Id,
            new Pattern() {Id = 1, Date= new DateTime(2017,07,23,20,29,29), Temperature= "27", Humidity="10", RealPower ="10", ActivePower ="10"},
            new Pattern() {Id = 2, Date= new DateTime(2017, 07, 23, 21, 29, 29), Temperature= "28", Humidity="10", RealPower ="12", ActivePower ="12"}
            );
        }
    }
}
