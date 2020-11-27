using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.UnitOfWork.Concrete;
using Kwork.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete.EntityManagers
{
    public class UserManager:IUserService
    {
        private readonly UnitOfWork _unitOfWork;
        public UserManager(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<User>> Get(int id)
        {
            var entity = await _unitOfWork.Users.GetAsync(c => c.Id == id);
            if (entity != null)
            {
                return new DataResult<User>(ResultStatus.Success, entity);
            }
            return new DataResult<User>(ResultStatus.Error, "Tahsil Dekontu Bulunamadı", null);
        }
        public async Task<IDataResult<IList<User>>> GetAll()
        {
            var entities = await _unitOfWork.Users.GetAllAsync(null, b => b.Role);
            if (entities.Count > -1)
            {
                return new DataResult<IList<User>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<User>>(ResultStatus.Error, "Tahsil Dekontu Bulunamadı", null);
        }
        public async Task<IDataResult<IList<User>>> GetAllByNonDeleted()
        {
            var entities = await _unitOfWork.Users.GetAllAsync(b => !b.IsDeleted, b => b.Role);
            if (entities.Count > -1)
            {
                return new DataResult<IList<User>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<User>>(ResultStatus.Error, "Kullanıcı Bulunamadı", null);
        }
        public async Task<IResult> Add(User user)
        {
            user.DeletedBy = null;
            user.IsDeleted = false;
            user.RecordDate = DateTime.Now;
            user.SoftDeleteDate = null;
            user.UpdateDate = DateTime.Now;

            await _unitOfWork.Users.AddAsync(user).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Kullanıcı başarıyla eklenmiştir.");
        }
        public async Task<IResult> Update(User user)
        {

            user.DeletedBy = null;
            user.IsDeleted = false;
            user.RecordDate = DateTime.Now;
            user.SoftDeleteDate = null;
            user.UpdateDate = DateTime.Now;

            await _unitOfWork.Users.UpdateAsync(user).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Kullanıcı başarıyla güncellenmiştir.");
        }
        public async Task<IResult> SoftDelete(int id)
        {
            var user = await _unitOfWork.Users.GetAsync(b => b.Id == id);
            await _unitOfWork.Users.SoftDeleteAsync(user).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Kullanıcı başarıyla silinmiştir.");
        }
        public async Task<IResult> HardDelete(int id)
        {
            var user = await _unitOfWork.Users.GetAsync(b => b.Id == id);
            await _unitOfWork.Users.HardDeleteAsync(user).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Kullanıcı başarıyla Database'den silinmiştir.");
        }
    }
}
