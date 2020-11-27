using DataAccess.Abstact;
using System;
using System.Threading.Tasks;

namespace Business.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IBirimKartRepository BirimKarts { get; }
        ICariKartRepository CariKarts { get; }
        IDepartmanKartRepository DepartmanKarts { get; }
        IKasaKartRepository KasaKarts { get; }
        IKasaVirmanRepository KasaVirmans { get; }
        IKDVRepository KDVs { get; }
        IMaasAvansDekontRepository MaasAvansDekonts { get; }
        IMasrafDekontRepository MasrafDekonts { get; }
        IMasrafKartRepository MasrafKarts { get; }
        IPersonelKartRepository PersonelKarts { get; }
        IRoleRepository Roles { get; }
        ITahsilDekontRepository TahsilDekonts { get; }
        ITediyeDekontRepository TediyeDekonts { get; }
        IUserRepository Users { get; }
        Task<int> SaveAsync();
    }
}
