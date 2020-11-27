using Core.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kwork.Entities.Concrete;

namespace Business.Abstract
{
    public interface ITahsilDekontService
    {
        Task<IDataResult<TahsilDekont>> Get(int id);
        Task<IDataResult<IList<TahsilDekont>>> GetAll();
        Task<IDataResult<IList<TahsilDekont>>> GetAllByNonDeleted();
        Task<IResult> Add(TahsilDekont tahsilDekont);
        Task<IResult> Update(TahsilDekont tahsilDekont);
        Task<IResult> SoftDelete(int id);
        Task<IResult> HardDelete(int id);
    }
}
