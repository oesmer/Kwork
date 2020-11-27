using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EfCore.Mappings
{
    internal class MaasAvansDekontMap : IEntityTypeConfiguration<MaasAvansDekont>
    {
        public void Configure(EntityTypeBuilder<MaasAvansDekont> builder)
        {
            builder.ToTable("MaasAvansDekonts");
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).ValueGeneratedOnAdd();

            builder.Property(I => I.Aciklama).HasMaxLength(500);
        }
    }
}