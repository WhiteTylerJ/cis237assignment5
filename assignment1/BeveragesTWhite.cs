namespace assignment1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BeveragesTWhite : DbContext
    {
        public BeveragesTWhite()
            : base("name=BeveragesTWhite")
        {
        }

        public virtual DbSet<Beverage> Beverages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beverage>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Beverage>()
                .Property(e => e.pack)
                .IsFixedLength();

            modelBuilder.Entity<Beverage>()
                .Property(e => e.price)
                .HasPrecision(19, 4);
        }
    }
}
