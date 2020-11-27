using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.EfCore.Mappings
{
    internal class DepartmanKartMap : IEntityTypeConfiguration<DepartmanKart>
    {
        public void Configure(EntityTypeBuilder<DepartmanKart> builder)
        {
            builder.ToTable("DepartmanKarts");
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).ValueGeneratedOnAdd();

            builder.Property(I => I.DepartmanAdi).HasMaxLength(50).IsRequired();
            builder.HasMany(e => e.Personel)
                .WithOne(e => e.Departman)
                .HasForeignKey(e => e.DepartmanID);
            builder.HasData(new DepartmanKart
            {
                Id = 1,
                DepartmanAdi = "Merkez",
                DeletedBy = null,
                IsDeleted = false,
                RecordDate = DateTime.Now,
                SoftDeleteDate = null,
                UpdateDate = DateTime.Now
            });

        }
    }
}