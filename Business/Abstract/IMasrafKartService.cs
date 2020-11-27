using Core.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kwork.Entities.Concrete;

namespace Business.Abstract
{
    public interface IMasrafKartService
    {
        Task<IDataResult<MasrafKart>> Get(int id);
        Task<IDataResult<IList<MasrafKart>>> GetAll();
        Task<IDataResult<IList<MasrafKart>>> GetAllByNonDeleted();
        Task<IResult> Add(MasrafKart masrafKart);
        Task<IResult> Update(MasrafKart masrafKart);
        Task<IResult> SoftDelete(int id);
        Task<IResult> HardDelete(int id);
    }
}
