using Core.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kwork.Entities.Concrete;

namespace Business.Abstract
{
    public interface ITediyeDekontService
    {
        Task<IDataResult<TediyeDekont>> Get(int id);
        Task<IDataResult<IList<TediyeDekont>>> GetAll();
        Task<IDataResult<IList<TediyeDekont>>> GetAllByNonDeleted();
        Task<IResult> Add(TediyeDekont tediyeDekont);
        Task<IResult> Update(TediyeDekont tediyeDekont);
        Task<IResult> SoftDelete(int id);
        Task<IResult> HardDelete(int id);
    }
}
