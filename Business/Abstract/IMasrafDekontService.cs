using Core.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kwork.Entities.Concrete;
namespace Business.Abstract
{
    public interface IMasrafDekontService
    {
        Task<IDataResult<MasrafDekont>> Get(int id);
        Task<IDataResult<IList<MasrafDekont>>> GetAll();
        Task<IDataResult<IList<MasrafDekont>>> GetAllByNonDeleted();
        Task<IResult> Add(MasrafDekont masrafDekont);
        Task<IResult> Update(MasrafDekont masrafDekont);
        Task<IResult> SoftDelete(int id);
        Task<IResult> HardDelete(int id);
    }
}
