//using Business.Abstract;
//using Core.DataAccess.Abstract;
//using Core.Utilities.Results.Abstract;
//using Core.Utilities.Results.ComplexTypes;
//using Core.Utilities.Results.Concrete;
//using Kwork.Core.Entities.Abstract;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Business.Concrete.EntityManagers
//{
//    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, IEntity, new()
//    {
//        private readonly IEntityRepository<TEntity> _repository;

//        public GenericManager(IEntityRepository<TEntity> repository)
//        {
//            _repository = repository;
//        }

//        public async Task<IResult> Add(TEntity entity)
//        {
//            entity.DeletedBy = null;
//            entity.IsDeleted = false;
//            entity.RecordDate = DateTime.Now;
//            entity.SoftDeleteDate = null;
//            entity.UpdateDate = DateTime.Now;

//            await _repository.AddAsync(entity).ContinueWith(t => _unitOfWork.SaveAsync());
//            return new Result(ResultStatus.Success, "Kayıt başarıyla eklenmiştir.");
//        }

//        public async Task<IDataResult<TEntity>> Get(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<IDataResult<IList<TEntity>>> GetAll()
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<IDataResult<IList<TEntity>>> GetAllByNonDeleted()
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<IResult> HardDelete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<IResult> SoftDelete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<IResult> Update(TEntity entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
