using Core.DataAccess.EfCore;
using DataAccess.Abstact;
using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfKDVRepository : EfEntityRepositoryBase<KDV>, IKDVRepository
    {
        public EfKDVRepository(DbContext context) : base(context)
        {

        }
    }
}
