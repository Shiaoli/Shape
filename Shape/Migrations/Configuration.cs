namespace Shape.Migrations
{
    using Shape.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shape.Models.RecordsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Shape.Models.RecordsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Records.AddOrUpdate(i => i.ID,
                new Record
                {
                    RecordDate = DateTime.Parse("2018-12-1"),
                    Weight = 120.2M,
                    Waist = 20
                },
                new Record
                {
                    RecordDate = DateTime.Parse("2019-1-12"),
                    Weight = 118.3M,
                    Waist = 19.5M
                },
                new Record
                {
                    RecordDate = DateTime.Parse("2019-3-12"),
                    Weight = 122.6M,
                    Waist = 20
                }
                );
        }
    }
}
