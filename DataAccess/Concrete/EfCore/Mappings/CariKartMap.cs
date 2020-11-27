using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EfCore.Mappings
{
    public class CariKartMap : IEntityTypeConfiguration<CariKart>
    {

        public void Configure(EntityTypeBuilder<CariKart> builder)
        {
            builder.ToTable("CariKarts");
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).ValueGeneratedOnAdd();

            builder.Property(I => I.Adres).HasMaxLength(500);
            builder.Property(I => I.CariAdi).HasMaxLength(100).IsRequired();
            builder.Property(I => I.CariSoyadi).HasMaxLength(100).IsRequired();
            builder.Property(I => I.FirmaAdi).HasMaxLength(100);
            builder.Property(I => I.VergiDairesi).HasMaxLength(100);
            builder.Property(I => I.VergiNo).HasMaxLength(100);
            builder.HasMany(e => e.TediyeDekont)
                .WithOne(e => e.CariKart)
                .HasForeignKey(e => e.CariID);
            builder.HasMany(e => e.TahsilDekont)
                .WithOne(e => e.CariKart)
                .HasForeignKey(e => e.CariID);
                

        }
    }
}