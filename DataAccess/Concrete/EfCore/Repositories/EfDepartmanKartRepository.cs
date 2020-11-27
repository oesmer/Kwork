using Core.DataAccess.EfCore;
using DataAccess.Abstact;
using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfDepartmanKartRepository : EfEntityRepositoryBase<DepartmanKart>, IDepartmanKartRepository
    {
        public EfDepartmanKartRepository(DbContext context) : base(context)
        {

        }
    }
}