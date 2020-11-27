using Core.DataAccess.EfCore;
using DataAccess.Abstact;
using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfMasrafDekontRepository : EfEntityRepositoryBase<MasrafDekont>, IMasrafDekontRepository
    {
        public EfMasrafDekontRepository(DbContext context) : base(context)
        {

        }
    }
}
