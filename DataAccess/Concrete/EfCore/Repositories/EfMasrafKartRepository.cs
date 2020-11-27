using Core.DataAccess.EfCore;
using DataAccess.Abstact;
using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfMasrafKartRepository : EfEntityRepositoryBase<MasrafKart>, IMasrafKartRepository
    {
        public EfMasrafKartRepository(DbContext context) : base(context)
        {

        }
    }
}
