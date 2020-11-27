using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EfCore.Mappings
{
    internal class TediyeDekontMap : IEntityTypeConfiguration<TediyeDekont>
    {
        public void Configure(EntityTypeBuilder<TediyeDekont> builder)
        {
            builder.ToTable("TediyeDekonts");
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).ValueGeneratedOnAdd();
            builder.Property(I => I.Aciklama).HasMaxLength(500).IsRequired(false);
        }
    }
}