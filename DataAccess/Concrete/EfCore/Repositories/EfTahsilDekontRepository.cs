using Core.DataAccess.EfCore;
using DataAccess.Abstact;
using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfTahsilDekontRepository : EfEntityRepositoryBase<TahsilDekont>, ITahsilDekontRepository
    {
        public EfTahsilDekontRepository(DbContext context) : base(context)
        {

        }
    }
}
