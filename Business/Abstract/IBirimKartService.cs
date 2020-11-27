using Core.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kwork.Entities.Concrete;

namespace Business.Abstract
{
    public interface IBirimKartService
    {
        Task<IDataResult<BirimKart>> Get(int id);
        Task<IDataResult<IList<BirimKart>>> GetAll();
        Task<IDataResult<IList<BirimKart>>> GetAllByNonDeleted();
        Task<IResult> Add(BirimKart birimKart);
        Task<IResult> Update(BirimKart birimKart);
        Task<IResult> SoftDelete(int id);
        Task<IResult> HardDelete(int id);
    }
}
