using Core.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kwork.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<User>> Get(int id);
        Task<IDataResult<IList<User>>> GetAll();
        Task<IDataResult<IList<User>>> GetAllByNonDeleted();
        Task<IResult> Add(User user);
        Task<IResult> Update(User user);
        Task<IResult> SoftDelete(int id);
        Task<IResult> HardDelete(int id);
    }
}
