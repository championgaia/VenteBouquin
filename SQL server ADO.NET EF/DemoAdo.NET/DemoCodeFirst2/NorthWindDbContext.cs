namespace DemoCodeFirst2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NorthWindDbContext : DbContext
    {
        public NorthWindDbContext()
            : base("name=NorthWindDbContext")
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .Property(e => e.CustomerID)
                .IsFixedLength();

            modelBuilder.Entity<Customers>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
