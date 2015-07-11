using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Based.DataAccess.Models;

namespace Based.DataAccess.Contexts
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(): base("DemoDb")
        {
        }

        public virtual DbSet<Detail> Detail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}