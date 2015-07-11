using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;
using Based.DataAccess.Contexts;
using Based.DataAccess.Migrations;

namespace Based.DataAccess.Config
{
    public class DemoDbConfiguration : DbConfiguration
    {
        public DemoDbConfiguration()
        {
            SetDefaultConnectionFactory(new SqlConnectionFactory("Data Source=DEV\\DEVELOPMENT;initial catalog=DemoDb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"));

            //SetDatabaseInitializer(new DropCreateDatabaseIfModelChanges<DemoDbContext>());

            //SetDatabaseInitializer(new NullDatabaseInitializer<DemoDbContext>());

            SetDatabaseInitializer(new MigrateDatabaseToLatestVersion<DemoDbContext, Configuration>());

            SetHistoryContext(SqlProviderServices.ProviderInvariantName, (connection, defaultSchema) => new DemoDbMigrationHistoryTableContext(connection, defaultSchema));     
        }
    }
}