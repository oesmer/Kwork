using Business.Concrete.EntityManagers;
using Business.UnitOfWork.Abstract;
using DataAccess.Abstact;
using DataAccess.Concrete.EfCore.Context;
using DataAccess.Concrete.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        private EfBirimKartRepository _birimKartRepository;
        private EfCariKartRepository _carikartRepository;
        private EfDepartmanKartRepository _departmanKartRepository;
        private EfKasaKartRepository _kasaKartRepository;
        private EfKasaVirmanRepository _kasaVirmanRepository;
        private EfKDVRepository _kDVRepository;
        private EfMaasAvansDekontRepository _maasAvansDekontRepository;
        private EfMasrafDekontRepository _masrafDekontRepository;
        private EfMasrafKartRepository _masrafKartRepository;
        private EfPersonelKartRepository _personelKartRepository;
        private EfRoleRepository _roleRepository;
        private EfTahsilDekontRepository _tahsilDekontRepository;
        private EfTediyeDekontRepository _tediyeDekontRepository;
        private EfUserRepository _userRepository;



        public IBirimKartRepository BirimKarts => _birimKartRepository ?? (_birimKartRepository = new EfBirimKartRepository(_context));
        public ICariKartRepository CariKarts => _carikartRepository ?? new EfCariKartRepository(_context);
        public IDepartmanKartRepository DepartmanKarts => _departmanKartRepository ?? new EfDepartmanKartRepository(_context);
        public IKasaKartRepository KasaKarts => _kasaKartRepository ?? new EfKasaKartRepository(_context);
        public IKasaVirmanRepository KasaVirmans => _kasaVirmanRepository ?? new EfKasaVirmanRepository(_context);
        public IKDVRepository KDVs => _kDVRepository ?? new EfKDVRepository(_context);
        public IMaasAvansDekontRepository MaasAvansDekonts => _maasAvansDekontRepository ?? new EfMaasAvansDekontRepository(_context);
        public IMasrafDekontRepository MasrafDekonts => _masrafDekontRepository ?? new EfMasrafDekontRepository(_context);
        public IMasrafKartRepository MasrafKarts => _masrafKartRepository ?? new EfMasrafKartRepository(_context);
        public IPersonelKartRepository PersonelKarts => _personelKartRepository ?? new EfPersonelKartRepository(_context);
        public IRoleRepository Roles => _roleRepository ?? new EfRoleRepository(_context);
        public ITahsilDekontRepository TahsilDekonts => _tahsilDekontRepository ?? new EfTahsilDekontRepository(_context);
        public ITediyeDekontRepository TediyeDekonts => _tediyeDekontRepository ?? new EfTediyeDekontRepository(_context);
        public IUserRepository Users => _userRepository ?? new EfUserRepository(_context);


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
