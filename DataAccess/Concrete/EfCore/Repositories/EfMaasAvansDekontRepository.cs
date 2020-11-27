using Core.DataAccess.EfCore;
using DataAccess.Abstact;
using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfMaasAvansDekontRepository : EfEntityRepositoryBase<MaasAvansDekont>, IMaasAvansDekontRepository
    {
        public EfMaasAvansDekontRepository(DbContext context) : base(context)
        {

        }
    }
}
