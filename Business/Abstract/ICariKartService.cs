using Core.Utilities.Results.Abstract;
using Kwork.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICariKartService
    {
        Task<IDataResult<CariKart>> Get(int id);
        Task<IDataResult<IList<CariKart>>> GetAll();
        Task<IDataResult<IList<CariKart>>> GetAllByNonDeleted();
        Task<IResult> Add(CariKart  cariKart);
        Task<IResult> Update(CariKart  cariKart);
        Task<IResult> SoftDelete(int id);
        Task<IResult> HardDelete(int id);
    }
}
