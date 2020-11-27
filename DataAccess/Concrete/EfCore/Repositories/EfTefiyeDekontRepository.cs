using Core.DataAccess.EfCore;
using DataAccess.Abstact;
using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfTediyeDekontRepository : EfEntityRepositoryBase<TediyeDekont>, ITediyeDekontRepository
    {
        public EfTediyeDekontRepository(DbContext context) : base(context)
        {

        }
    }
}
