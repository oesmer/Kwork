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
    public class MasrafDekontManager:IMasrafDekontService
    {
        private readonly UnitOfWork _unitOfWork;
        public MasrafDekontManager(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<MasrafDekont>> Get(int id)
        {
            var entity = await _unitOfWork.MasrafDekonts.GetAsync(c => c.Id == id);
            if (entity != null)
            {
                return new DataResult<MasrafDekont>(ResultStatus.Success, entity);
            }
            return new DataResult<MasrafDekont>(ResultStatus.Error, "Masraf Dekontu Bulunamadı", null);
        }
        public async Task<IDataResult<IList<MasrafDekont>>> GetAll()
        {
            var entities = await _unitOfWork.MasrafDekonts.GetAllAsync(null, b => b.KasaKart,c=>c.MasrafKart);
            if (entities.Count > -1)
            {
                return new DataResult<IList<MasrafDekont>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<MasrafDekont>>(ResultStatus.Error, "Masraf Dekontu Bulunamadı", null);
        }
        public async Task<IDataResult<IList<MasrafDekont>>> GetAllByNonDeleted()
        {
            var entities = await _unitOfWork.MasrafDekonts.GetAllAsync(b => !b.IsDeleted, b => b.KasaKart, c => c.MasrafKart);
            if (entities.Count > -1)
            {
                return new DataResult<IList<MasrafDekont>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<MasrafDekont>>(ResultStatus.Error, "Masraf Dekontu Bulunamadı", null);
        }
        public async Task<IResult> Add(MasrafDekont masrafDekont)
        {
            masrafDekont.DeletedBy = null;
            masrafDekont.IsDeleted = false;
            masrafDekont.RecordDate = DateTime.Now;
            masrafDekont.SoftDeleteDate = null;
            masrafDekont.UpdateDate = DateTime.Now;

            await _unitOfWork.MasrafDekonts.AddAsync(masrafDekont).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Masraf Dekontu başarıyla eklenmiştir.");
        }
        public async Task<IResult> Update(MasrafDekont masrafDekont)
        {

            masrafDekont.DeletedBy = null;
            masrafDekont.IsDeleted = false;
            masrafDekont.RecordDate = DateTime.Now;
            masrafDekont.SoftDeleteDate = null;
            masrafDekont.UpdateDate = DateTime.Now;

            await _unitOfWork.MasrafDekonts.UpdateAsync(masrafDekont).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Masraf Dekontu başarıyla güncellenmiştir.");
        }
        public async Task<IResult> SoftDelete(int id)
        {
            var masrafDekont = await _unitOfWork.MasrafDekonts.GetAsync(b => b.Id == id);
            await _unitOfWork.MasrafDekonts.SoftDeleteAsync(masrafDekont).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Masraf Dekontu başarıyla silinmiştir.");
        }
        public async Task<IResult> HardDelete(int id)
        {
            var masrafDekont = await _unitOfWork.MasrafDekonts.GetAsync(b => b.Id == id);
            await _unitOfWork.MasrafDekonts.HardDeleteAsync(masrafDekont).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Masraf Dekontu başarıyla Database'den silinmiştir.");
        }
    }
}
