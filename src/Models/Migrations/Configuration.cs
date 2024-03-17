using System.Data.Entity.Migrations;

namespace Models.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Models.ApplicationDBContext";
        }

        protected override void Seed(Models.ApplicationDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}