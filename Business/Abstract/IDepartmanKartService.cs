using Core.Utilities.Results.Abstract;
using Kwork.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDepartmanKartService
    {
        Task<IDataResult<DepartmanKart>> Get(int id);
        Task<IDataResult<IList<DepartmanKart>>> GetAll();
        Task<IDataResult<IList<DepartmanKart>>> GetAllByNonDeleted();
        Task<IResult> Add(DepartmanKart departmanKart);
        Task<IResult> Update(DepartmanKart departmanKart);
        Task<IResult> SoftDelete(int id);
        Task<IResult> HardDelete(int id);
    }
}
