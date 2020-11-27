using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.EfCore.Mappings
{
    public class KDVMap : IEntityTypeConfiguration<KDV>
    {
        public void Configure(EntityTypeBuilder<KDV> builder)
        {
            builder.ToTable("KDVs");
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).ValueGeneratedOnAdd();
            builder.HasMany(e => e.MasrafDekont)
                .WithOne(e => e.KDV)
                .HasForeignKey(e=>e.KDVID);
            builder.HasData(new KDV
            {
                Id = 1,
                KDVOrani = 18,
                DeletedBy = null,
                IsDeleted = false,
                RecordDate = DateTime.Now,
                SoftDeleteDate = null,
                UpdateDate = DateTime.Now
            });
        }
    }
}