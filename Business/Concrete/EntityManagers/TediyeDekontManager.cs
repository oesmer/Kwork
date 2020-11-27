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
    public class TediyeDekontManager:ITediyeDekontService
    {
        private readonly UnitOfWork _unitOfWork;
        public TediyeDekontManager(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<TediyeDekont>> Get(int id)
        {
            var entity = await _unitOfWork.TediyeDekonts.GetAsync(c => c.Id == id);
            if (entity != null)
            {
                return new DataResult<TediyeDekont>(ResultStatus.Success, entity);
            }
            return new DataResult<TediyeDekont>(ResultStatus.Error, "Tahsil Dekontu Bulunamadı", null);
        }
        public async Task<IDataResult<IList<TediyeDekont>>> GetAll()
        {
            var entities = await _unitOfWork.TediyeDekonts.GetAllAsync(null, b => b.CariKart, c => c.KasaKart);
            if (entities.Count > -1)
            {
                return new DataResult<IList<TediyeDekont>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<TediyeDekont>>(ResultStatus.Error, "Tahsil Dekontu Bulunamadı", null);
        }
        public async Task<IDataResult<IList<TediyeDekont>>> GetAllByNonDeleted()
        {
            var entities = await _unitOfWork.TediyeDekonts.GetAllAsync(b => !b.IsDeleted,
                b => b.CariKart, c => c.KasaKart);
            if (entities.Count > -1)
            {
                return new DataResult<IList<TediyeDekont>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<TediyeDekont>>(ResultStatus.Error, "Tediye Dekontu Bulunamadı", null);
        }
        public async Task<IResult> Add(TediyeDekont tediyeDekont)
        {
            tediyeDekont.DeletedBy = null;
            tediyeDekont.IsDeleted = false;
            tediyeDekont.RecordDate = DateTime.Now;
            tediyeDekont.SoftDeleteDate = null;
            tediyeDekont.UpdateDate = DateTime.Now;

            await _unitOfWork.TediyeDekonts.AddAsync(tediyeDekont).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Tediye Dekontu başarıyla eklenmiştir.");
        }
        public async Task<IResult> Update(TediyeDekont tediyeDekont)
        {

            tediyeDekont.DeletedBy = null;
            tediyeDekont.IsDeleted = false;
            tediyeDekont.RecordDate = DateTime.Now;
            tediyeDekont.SoftDeleteDate = null;
            tediyeDekont.UpdateDate = DateTime.Now;

            await _unitOfWork.TediyeDekonts.UpdateAsync(tediyeDekont).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Tediye Dekontu başarıyla güncellenmiştir.");
        }
        public async Task<IResult> SoftDelete(int id)
        {
            var tediyeDekont = await _unitOfWork.TediyeDekonts.GetAsync(b => b.Id == id);
            await _unitOfWork.TediyeDekonts.SoftDeleteAsync(tediyeDekont).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Tediye Dekontu başarıyla silinmiştir.");
        }
        public async Task<IResult> HardDelete(int id)
        {
            var tediyeDekont = await _unitOfWork.TediyeDekonts.GetAsync(b => b.Id == id);
            await _unitOfWork.TediyeDekonts.HardDeleteAsync(tediyeDekont).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Tediye Dekontu başarıyla Database'den silinmiştir.");
        }
    }
}
