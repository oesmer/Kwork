using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.EfCore.Mappings
{
    internal class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).ValueGeneratedOnAdd();

            builder.Property(I => I.Name).HasMaxLength(50).IsRequired();
            builder
                .HasMany(e => e.Users)
                .WithOne(e => e.Role)
                .HasForeignKey(e => e.RoleID);
            builder.HasData(new Role
            {
                Id = 1,
                Name = "Admin",
                DeletedBy = null,
                IsDeleted = false,
                RecordDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                SoftDeleteDate = null
            });
        }
    }
}