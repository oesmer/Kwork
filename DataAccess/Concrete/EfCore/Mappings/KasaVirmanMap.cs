using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EfCore.Mappings
{
    internal class KasaVirmanMap : IEntityTypeConfiguration<KasaVirman>
    {
        public void Configure(EntityTypeBuilder<KasaVirman> builder)
        {
            builder.ToTable("KasaVirmans");
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).ValueGeneratedOnAdd();

            builder.Property(I => I.Aciklama).HasMaxLength(500);
        }
    }
}