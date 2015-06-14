using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;

namespace Based.DataAccess.Contexts
{
    public class DemoDbMigrationHistoryTableContext : HistoryContext
    {
        public DemoDbMigrationHistoryTableContext(DbConnection existingConnection, string defaultSchema) : base(existingConnection, defaultSchema)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("History");
            modelBuilder.Entity<HistoryRow>().ToTable("DemoDbMigration", "History");
        }
    }
}