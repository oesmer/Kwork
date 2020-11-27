using Core.DataAccess.EfCore;
using DataAccess.Abstact;
using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfCariKartRepository : EfEntityRepositoryBase<CariKart>, ICariKartRepository
    {
        public EfCariKartRepository(DbContext context) : base(context)
        {

        }
    }
}
