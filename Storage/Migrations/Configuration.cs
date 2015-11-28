namespace Storage.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// This class is used to update the database schema upon changes. 
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<Storage.AutoSysDbModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        /// <summary>
        /// Called after migrating to the latest version or updating the database. 
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(Storage.AutoSysDbModel context)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AutoSysDbModel>());
            context.Database.CreateIfNotExists();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
