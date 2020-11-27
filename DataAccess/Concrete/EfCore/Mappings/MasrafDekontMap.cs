using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EfCore.Mappings
{
    public class MasrafDekontMap : IEntityTypeConfiguration<MasrafDekont>
    {
        public void Configure(EntityTypeBuilder<MasrafDekont> builder)
        {
            builder.ToTable("MasrafDekonts");
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).ValueGeneratedOnAdd();

            builder.Property(I => I.Aciklama).HasMaxLength(500);
        }
    }
}