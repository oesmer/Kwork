using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.EfCore.Mappings
{
    public class MasrafKartMap : IEntityTypeConfiguration<MasrafKart>
    {
        public void Configure(EntityTypeBuilder<MasrafKart> builder)
        {
            builder.ToTable("MasrafKarts");
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).ValueGeneratedOnAdd();

            builder.Property(I => I.MasrafAdi).HasMaxLength(50);

            builder.HasMany(e => e.MasrafDekont)
                .WithOne(e => e.MasrafKart)
                .HasForeignKey(e => e.MasrafKartID);
            builder.HasData(new MasrafKart
            {
                Id = 1,
                MasrafAdi = "Genel Masraflar",
                DeletedBy = null,
                IsDeleted = false,
                RecordDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                SoftDeleteDate = null
            });

            
        }
    }
}