//using Core.Utilities.Results.Abstract;
//using Kwork.Core.Entities.Abstract;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace Business.Abstract
//{
//    public interface IGenericService<T> where T : class, IEntity, new()
//    {
//        Task<IDataResult<T>> Get(int id);
//        Task<IDataResult<IList<T>>> GetAll();
//        Task<IDataResult<IList<T>>> GetAllByNonDeleted();
//        Task<IResult> Add(T entity);
//        Task<IResult> Update(T entity);
//        Task<IResult> SoftDelete(int id);
//        Task<IResult> HardDelete(int id);
//    }
//}
