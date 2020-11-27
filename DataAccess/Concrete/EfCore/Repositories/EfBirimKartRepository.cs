using Core.DataAccess.EfCore;
using DataAccess.Abstact;
using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfBirimKartRepository : EfEntityRepositoryBase<BirimKart>, IBirimKartRepository
    {
        public EfBirimKartRepository(DbContext context) : base(context)
        {

        }
    }
}

