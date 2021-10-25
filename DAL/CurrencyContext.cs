using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace MyWebIpi.Contexts
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext(DbContextOptions options):base(options){}
        internal DbSet<CurrencyHistoryValue> CurrencyHistoryValues { get; set; }
        internal DbSet<CurrencyValue> Currences { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CurrencyValue>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).HasColumnType("char").IsRequired();

            });

            modelBuilder.Entity<CurrencyHistoryValue>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.BidPrice).HasColumnType("float").IsRequired();
                entity.Property(e => e.AskPrice).HasColumnType("float").IsRequired();
                entity.Property(e => e.BidVolum).HasColumnType("float").IsRequired();
                entity.Property(e => e.AskVolum).HasColumnType("float").IsRequired();
                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.CurrencyHistoryValues);

            });

        }
    }
}