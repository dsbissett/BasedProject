using System.Data.Entity.Migrations;
using Based.DataAccess.Contexts;

namespace Based.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DemoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}