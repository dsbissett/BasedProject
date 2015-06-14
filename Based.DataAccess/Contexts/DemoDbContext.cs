using System.Data.Entity;
using Based.DataAccess.Models;

namespace Based.DataAccess.Contexts
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(): base("DemoDb")
        {
        }

        public virtual DbSet<Detail> Details { get; set; }
    }
}