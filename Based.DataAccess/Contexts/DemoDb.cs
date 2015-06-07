using System.Data.Entity;
using Based.DataAccess.Models;

namespace Based.DataAccess.Contexts
{
    public class DemoDb : DbContext
    {
        public DemoDb() : base("name=DemoDb")
        {
        }

        public virtual DbSet<Detail> Detail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detail>()
                .Property(e => e.Id);

            modelBuilder.Entity<Detail>()
                .Property(e => e.CustomerId);

            modelBuilder.Entity<Detail>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.StreetNumber);                

            modelBuilder.Entity<Detail>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.Address3)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.PostalCode);

            modelBuilder.Entity<Detail>()
                .Property(e => e.PrimaryPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.SecondaryPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.RowVersionUser)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.RowCreatedUser)
                .IsUnicode(false);
        }
    }
}
