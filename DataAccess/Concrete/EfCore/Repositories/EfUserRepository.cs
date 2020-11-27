using Core.DataAccess.EfCore;
using DataAccess.Abstact;
using Kwork.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfUserRepository:EfEntityRepositoryBase<User>,IUserRepository
    {
        public EfUserRepository(DbContext context) : base(context)
        {
        }
    }
}
