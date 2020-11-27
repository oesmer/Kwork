using Core.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kwork.Entities.Concrete;

namespace Business.Abstract
{
    public interface IPersonelKartService
    {
        Task<IDataResult<PersonelKart>> Get(int id);
        Task<IDataResult<IList<PersonelKart>>> GetAll();
        Task<IDataResult<IList<PersonelKart>>> GetAllByNonDeleted();
        Task<IResult> Add(PersonelKart personelKart);
        Task<IResult> Update(PersonelKart personelKart);
        Task<IResult> SoftDelete(int id);
        Task<IResult> HardDelete(int id);
    }
}
