using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EfCore.Mappings
{
    public class TahsilDekontMap : IEntityTypeConfiguration<TahsilDekont>
    {
        public void Configure(EntityTypeBuilder<TahsilDekont> builder)
        {
            builder.ToTable("TahsilDekonts");
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).ValueGeneratedOnAdd();

            builder.Property(I => I.Aciklama).HasMaxLength(500).IsRequired(false);
           
        }
    }
}