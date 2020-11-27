using Core.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kwork.Entities.Concrete;
namespace Business.Abstract
{
    public interface IMaasAvansDekontService
    {
        Task<IDataResult<MaasAvansDekont>> Get(int id);
        Task<IDataResult<IList<MaasAvansDekont>>> GetAll();
        Task<IDataResult<IList<MaasAvansDekont>>> GetAllByNonDeleted();
        Task<IResult> Add(MaasAvansDekont maasAvansDekont);
        Task<IResult> Update(MaasAvansDekont maasAvansDekont);
        Task<IResult> SoftDelete(int id);
        Task<IResult> HardDelete(int id);
    }
}
