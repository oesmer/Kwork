using Core.DataAccess.EfCore;
using DataAccess.Abstact;
using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfKasaVirmanRepository : EfEntityRepositoryBase<KasaVirman>, IKasaVirmanRepository
    {
        public EfKasaVirmanRepository(DbContext context) : base(context)
        {

        }
    }
}
