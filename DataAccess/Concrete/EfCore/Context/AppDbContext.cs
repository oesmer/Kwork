using DataAccess.Concrete.EfCore.Mappings;
using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCore.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=OENP730\\SQLEXPRESS;initial catalog=kwork;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }
        public DbSet<BirimKart> BirimKarts { get; set; }
        public DbSet<CariKart> CariKarts { get; set; }
        public DbSet<DepartmanKart> Departmans { get; set; }
        public DbSet<KasaKart> KasaKarts { get; set; }
        public DbSet<KasaVirman> KasaVirmans { get; set; }
        public DbSet<KDV> KDVs { get; set; }
        public DbSet<MaasAvansDekont> MaasAvansDekonts { get; set; }
        public DbSet<MasrafDekont> MasrafDekonts { get; set; }
        public DbSet<MasrafKart> MasrafKarts { get; set; }
        public DbSet<PersonelKart> Personels { get; set; }
        public DbSet<TahsilDekont> TahsilDekonts { get; set; }
        public DbSet<TediyeDekont> TediyeDekonts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BirimKartMap());
            modelBuilder.ApplyConfiguration(new CariKartMap());
            modelBuilder.ApplyConfiguration(new DepartmanKartMap());
            modelBuilder.ApplyConfiguration(new KasaKartMap());
            modelBuilder.ApplyConfiguration(new KasaVirmanMap());
            modelBuilder.ApplyConfiguration(new KDVMap());
            modelBuilder.ApplyConfiguration(new MaasAvansDekontMap()); 
            modelBuilder.ApplyConfiguration(new MasrafDekontMap());
            modelBuilder.ApplyConfiguration(new MasrafKartMap()); 
            modelBuilder.ApplyConfiguration(new PersonelKartMap());
            modelBuilder.ApplyConfiguration(new TahsilDekontMap());
            modelBuilder.ApplyConfiguration(new TediyeDekontMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
        }
    }
}
