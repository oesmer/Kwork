using Core.DataAccess.EfCore;
using DataAccess.Abstact;
using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfKasaKartRepository : EfEntityRepositoryBase<KasaKart>, IKasaKartRepository
    {
        public EfKasaKartRepository(DbContext context) : base(context)
        {

        }
    }
}
