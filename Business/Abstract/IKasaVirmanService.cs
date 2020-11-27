using Core.Utilities.Results.Abstract;
using Kwork.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Business.Abstract
{
    public interface IKasaVirmanService
    {
        Task<IDataResult<KasaVirman>> Get(int id);
        Task<IDataResult<IList<KasaVirman>>> GetAll();
        Task<IDataResult<IList<KasaVirman>>> GetAllByNonDeleted();
        Task<IResult> Add(KasaVirman kasaVirman);
        Task<IResult> Update(KasaVirman kasaVirman);
        Task<IResult> SoftDelete(int id);
        Task<IResult> HardDelete(int id);
    }
}
