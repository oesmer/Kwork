using Business.Abstract;
using Business.UOW.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using Kwork.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete.EntityManagers
{
    public class CariKartManager: ICariKartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CariKartManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<CariKart>> Get(int id)
        {
            var entity = await _unitOfWork.CariKarts.GetAsync(c => c.Id == id);
            if (entity != null)
            {
                return new DataResult<CariKart>(ResultStatus.Success, entity);
            }
            return new DataResult<CariKart>(ResultStatus.Error, "Birim Kartı Bulunamadı", null);
        }
        public async Task<IDataResult<IList<CariKart>>> GetAll()
        {
            var entities = await _unitOfWork.CariKarts.GetAllAsync(null, b => b.TahsilDekont,c=>c.TediyeDekont);
            if (entities.Count > -1)
            {
                return new DataResult<IList<CariKart>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<CariKart>>(ResultStatus.Error, "Cari Kart Bulunamadı", null);
        }
        public async Task<IDataResult<IList<CariKart>>> GetAllByNonDeleted()
        {
            var entities = await _unitOfWork.CariKarts.GetAllAsync(b => !b.IsDeleted, b => b.TahsilDekont, c => c.TediyeDekont);
            if (entities.Count > -1)
            {
                return new DataResult<IList<CariKart>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<CariKart>>(ResultStatus.Error, "Cari Kart Bulunamadı", null);
        }
        public async Task<IResult> Add(CariKart cariKart)
        {
            cariKart.DeletedBy = null;
            cariKart.IsDeleted = false;
            cariKart.RecordDate = DateTime.Now;
            cariKart.SoftDeleteDate = null;
            cariKart.UpdateDate = DateTime.Now;

            await _unitOfWork.CariKarts.AddAsync(cariKart).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{cariKart.CariAdi} başarıyla eklenmiştir.");
        }
        public async Task<IResult> Update(CariKart cariKart)
        {

            cariKart.DeletedBy = null;
            cariKart.IsDeleted = false;
            cariKart.RecordDate = DateTime.Now;
            cariKart.SoftDeleteDate = null;
            cariKart.UpdateDate = DateTime.Now;

            await _unitOfWork.CariKarts.UpdateAsync(cariKart).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{cariKart.CariAdi} başarıyla güncellenmiştir.");
        }
        public async Task<IResult> SoftDelete(int id)
        {
            var cariKart = await _unitOfWork.CariKarts.GetAsync(b => b.Id == id);
            await _unitOfWork.CariKarts.SoftDeleteAsync(cariKart).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{cariKart.CariAdi} başarıyla silinmiştir.");
        }
        public async Task<IResult> HardDelete(int id)
        {
            var cariKart = await _unitOfWork.CariKarts.GetAsync(b => b.Id == id);
            await _unitOfWork.CariKarts.HardDeleteAsync(cariKart).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{cariKart.CariAdi} başarıyla Database'den silinmiştir.");
        }
    }
}
