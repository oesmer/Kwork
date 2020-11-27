using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.EfCore.Mappings
{
    public class KasaKartMap : IEntityTypeConfiguration<KasaKart>
    {
        public void Configure(EntityTypeBuilder<KasaKart> builder)
        {
            builder.ToTable("KasaKarts");
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).ValueGeneratedOnAdd();

            builder.Property(I => I.Aciklama).HasMaxLength(500);
            builder.Property(I => I.KasaAdi).HasMaxLength(100).IsRequired();

            builder.HasMany(e => e.TediyeDekont)
                .WithOne(e => e.KasaKart)
                .HasForeignKey(e => e.KasaKartID);
            builder.HasMany(e => e.TahsilDekont)
                .WithOne(e => e.KasaKart)
                .HasForeignKey(e => e.KasaKartID);
             builder.HasMany(e => e.MasrafDekont)
                 .WithOne(e => e.KasaKart)
                 .HasForeignKey(e=>e.KasaKartID);
            builder.HasMany(e => e.MaasAvansDekont)
                .WithOne(e => e.KasaKart)
                .HasForeignKey(e => e.KasaKartID);
            builder.HasMany(e => e.HedefKasa)
                .WithOne(e => e.HedefKasaKart)
                .HasForeignKey(e => e.HedefKasaID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.KaynakKasa)
                .WithOne(e => e.KaynakKasaKart)
                .HasForeignKey(e => e.KaynakKasaID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new KasaKart
            {
                Id = 1,
                KasaAdi = "Merkez",
                Aciklama = "Merkez Kasası",
                DeletedBy = null,
                IsDeleted = false,
                KasaBakiye = 0,
                RecordDate = DateTime.Now,
                SoftDeleteDate = null,
                UpdateDate = DateTime.Now
            });
        }
    }
}