using Core.Utilities.Results.Abstract;
using Kwork.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Business.Abstract
{
    public interface IKasaKartService
    {
        Task<IDataResult<KasaKart>> Get(int id);
        Task<IDataResult<IList<KasaKart>>> GetAll();
        Task<IDataResult<IList<KasaKart>>> GetAllByNonDeleted();
        Task<IResult> Add(KasaKart kasaKart);
        Task<IResult> Update(KasaKart kasaKart);
        Task<IResult> SoftDelete(int id);
        Task<IResult> HardDelete(int id);
    }
}
