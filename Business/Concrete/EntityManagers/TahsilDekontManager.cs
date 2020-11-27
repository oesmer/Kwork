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
    public class TahsilDekontManager:ITahsilDekontService
    {
        private readonly UnitOfWork _unitOfWork;
        public TahsilDekontManager(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<TahsilDekont>> Get(int id)
        {
            var entity = await _unitOfWork.TahsilDekonts.GetAsync(c => c.Id == id);
            if (entity != null)
            {
                return new DataResult<TahsilDekont>(ResultStatus.Success, entity);
            }
            return new DataResult<TahsilDekont>(ResultStatus.Error, "Tahsil Dekontu Bulunamadı", null);
        }
        public async Task<IDataResult<IList<TahsilDekont>>> GetAll()
        {
            var entities = await _unitOfWork.TahsilDekonts.GetAllAsync(null, b => b.CariKart, c => c.KasaKart);
            if (entities.Count > -1)
            {
                return new DataResult<IList<TahsilDekont>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<TahsilDekont>>(ResultStatus.Error, "Tahsil Dekontu Bulunamadı", null);
        }
        public async Task<IDataResult<IList<TahsilDekont>>> GetAllByNonDeleted()
        {
            var entities = await _unitOfWork.TahsilDekonts.GetAllAsync(b => !b.IsDeleted,
                b => b.CariKart, c => c.KasaKart);
            if (entities.Count > -1)
            {
                return new DataResult<IList<TahsilDekont>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<TahsilDekont>>(ResultStatus.Error, "Tahsil Dekontu Bulunamadı", null);
        }
        public async Task<IResult> Add(TahsilDekont tahsilDekont)
        {
            tahsilDekont.DeletedBy = null;
            tahsilDekont.IsDeleted = false;
            tahsilDekont.RecordDate = DateTime.Now;
            tahsilDekont.SoftDeleteDate = null;
            tahsilDekont.UpdateDate = DateTime.Now;

            await _unitOfWork.TahsilDekonts.AddAsync(tahsilDekont).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Tahsil Dekontu başarıyla eklenmiştir.");
        }
        public async Task<IResult> Update(TahsilDekont tahsilDekont)
        {

            tahsilDekont.DeletedBy = null;
            tahsilDekont.IsDeleted = false;
            tahsilDekont.RecordDate = DateTime.Now;
            tahsilDekont.SoftDeleteDate = null;
            tahsilDekont.UpdateDate = DateTime.Now;

            await _unitOfWork.TahsilDekonts.UpdateAsync(tahsilDekont).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Tahsil Dekontu başarıyla güncellenmiştir.");
        }
        public async Task<IResult> SoftDelete(int id)
        {
            var tahsilDekont = await _unitOfWork.TahsilDekonts.GetAsync(b => b.Id == id);
            await _unitOfWork.TahsilDekonts.SoftDeleteAsync(tahsilDekont).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Tahsil Dekontu başarıyla silinmiştir.");
        }
        public async Task<IResult> HardDelete(int id)
        {
            var tahsilDekont = await _unitOfWork.TahsilDekonts.GetAsync(b => b.Id == id);
            await _unitOfWork.TahsilDekonts.HardDeleteAsync(tahsilDekont).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Tahsil Dekontu başarıyla Database'den silinmiştir.");
        }
    }
}
