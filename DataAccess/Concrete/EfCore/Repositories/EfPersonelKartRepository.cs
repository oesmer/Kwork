using Core.DataAccess.EfCore;
using DataAccess.Abstact;
using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfPersonelKartRepository : EfEntityRepositoryBase<PersonelKart>, IPersonelKartRepository
    {
        public EfPersonelKartRepository(DbContext context) : base(context)
        {

        }
    }
}
