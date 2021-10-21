using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace MyWebIpi.Contexts
{
    public class CriptoCoinValueContext : DbContext
    {
        public CriptoCoinValueContext(DbContextOptions options):base(options){}
        internal DbSet<CriptoCoinValue> CriptoCoinValues { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CriptoCoinValue>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Time).IsRequired().HasColumnType("bigint");
                entity.Property(e => e.PriceUsd).IsRequired().HasColumnType("tinytext");
            });
        }
    }
}