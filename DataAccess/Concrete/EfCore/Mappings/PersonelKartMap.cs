using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EfCore.Mappings
{
    public class PersonelKartMap : IEntityTypeConfiguration<PersonelKart>
    {
        public void Configure(EntityTypeBuilder<PersonelKart> builder)
        {
            builder.ToTable("PersonelKarts");
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).ValueGeneratedOnAdd();

            builder.Property(I => I.IBAN).HasMaxLength(24);
            builder.Property(I => I.PersonelAdi).HasMaxLength(100).IsRequired();
            builder.Property(I => I.PersonelSoyadi).HasMaxLength(100).IsRequired();
            builder.Property(I => I.TCNo).HasMaxLength(11);
            builder.Property(I => I.TelNo).HasMaxLength(10);

            builder.HasMany(e => e.MaasAvansDekont)
                .WithOne(e => e.Personel)
                .HasForeignKey(e => e.PersonelID);

            builder.HasMany(e => e.AltPersonels)
                .WithOne(e => e.UstPersonel).HasForeignKey(e => e.UstPersonelID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}