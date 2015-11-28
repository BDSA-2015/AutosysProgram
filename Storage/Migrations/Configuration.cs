using Storage.Entities;

namespace Storage.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Storage.AutoSysDbModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// This method will be called after migrating to the latest version.
        /// </summary>
        /// <param name="context">
        /// Database target. 
        /// </param>
        protected override void Seed(Storage.AutoSysDbModel context)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AutoSysDbModel>());
            context.Users.Add(new StoredUser {Name = "Test", MetaData = "MetaTest"});

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
