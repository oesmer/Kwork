using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.EfCore.Mappings
{
    internal class BirimKartMap : IEntityTypeConfiguration<BirimKart>
    {
        public void Configure(EntityTypeBuilder<BirimKart> builder)
        {
            builder.ToTable("BirimKarts");
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).ValueGeneratedOnAdd();

            builder.Property(I => I.BirimAdi).HasMaxLength(50).IsRequired();
            builder
                .HasMany(e => e.MasrafDekonts)
                .WithOne(e => e.BirimKart)
                .HasForeignKey(e => e.BirimKartID);
            builder.HasData(new BirimKart
            {
                Id = 1,
                BirimAdi = "Adet",
                DeletedBy = null,
                IsDeleted = false,
                RecordDate = DateTime.Now,
                SoftDeleteDate = null,
                UpdateDate = DateTime.Now
            });
        }
    }
}