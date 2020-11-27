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
    public class MasrafKartManager:IMasrafKartService
    {
        private readonly UnitOfWork _unitOfWork;
        public MasrafKartManager(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<MasrafKart>> Get(int id)
        {
            var entity = await _unitOfWork.MasrafKarts.GetAsync(c => c.Id == id);
            if (entity != null)
            {
                return new DataResult<MasrafKart>(ResultStatus.Success, entity);
            }
            return new DataResult<MasrafKart>(ResultStatus.Error, "Masraf Kartı Bulunamadı", null);
        }
        public async Task<IDataResult<IList<MasrafKart>>> GetAll()
        {
            var entities = await _unitOfWork.MasrafKarts.GetAllAsync(null, b => b.MasrafDekont);
            if (entities.Count > -1)
            {
                return new DataResult<IList<MasrafKart>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<MasrafKart>>(ResultStatus.Error, "Masraf Kartı Bulunamadı", null);
        }
        public async Task<IDataResult<IList<MasrafKart>>> GetAllByNonDeleted()
        {
            var entities = await _unitOfWork.MasrafKarts.GetAllAsync(b => !b.IsDeleted, b => b.MasrafDekont);
            if (entities.Count > -1)
            {
                return new DataResult<IList<MasrafKart>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<MasrafKart>>(ResultStatus.Error, "Masraf Kartı Bulunamadı", null);
        }
        public async Task<IResult> Add(MasrafKart masrafKart)
        {
            masrafKart.DeletedBy = null;
            masrafKart.IsDeleted = false;
            masrafKart.RecordDate = DateTime.Now;
            masrafKart.SoftDeleteDate = null;
            masrafKart.UpdateDate = DateTime.Now;

            await _unitOfWork.MasrafKarts.AddAsync(masrafKart).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Masraf Kartı başarıyla eklenmiştir.");
        }
        public async Task<IResult> Update(MasrafKart masrafKart)
        {

            masrafKart.DeletedBy = null;
            masrafKart.IsDeleted = false;
            masrafKart.RecordDate = DateTime.Now;
            masrafKart.SoftDeleteDate = null;
            masrafKart.UpdateDate = DateTime.Now;

            await _unitOfWork.MasrafKarts.UpdateAsync(masrafKart).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Masraf Kartı başarıyla güncellenmiştir.");
        }
        public async Task<IResult> SoftDelete(int id)
        {
            var masrafKart = await _unitOfWork.MasrafKarts.GetAsync(b => b.Id == id);
            await _unitOfWork.MasrafKarts.SoftDeleteAsync(masrafKart).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Masraf Kartı başarıyla silinmiştir.");
        }
        public async Task<IResult> HardDelete(int id)
        {
            var masrafKart = await _unitOfWork.MasrafKarts.GetAsync(b => b.Id == id);
            await _unitOfWork.MasrafKarts.HardDeleteAsync(masrafKart).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Masraf Kartı başarıyla Database'den silinmiştir.");
        }
    }
}
