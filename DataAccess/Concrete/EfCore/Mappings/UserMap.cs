using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Text;

namespace DataAccess.Concrete.EfCore.Mappings
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).ValueGeneratedOnAdd();

            builder.Property(I => I.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(I => I.LastName).HasMaxLength(50).IsRequired();
            builder.Property(I => I.Email).HasMaxLength(150).IsRequired();
            builder
                .HasOne(e => e.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.RoleID);
            builder.HasData(new User
            {
                Id = 1,
                FirstName = "Ocal",
                LastName = "Esmer",
                Email = "oesmer@gmail.com",
                RoleID = 1,
                UserName = "oesmer",
                DeletedBy = null,
                SoftDeleteDate = null,
                IsDeleted = false,
                RecordDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                PasswordHash = Encoding.ASCII.GetBytes("a001c7e3406bd26f1645bf1070f56a2c")
            });
        }
    }
}