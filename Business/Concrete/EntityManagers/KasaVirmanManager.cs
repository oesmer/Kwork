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
    public class KasaVirmanManager:IKasaVirmanService
    {
        private readonly IUnitOfWork _unitOfWork;
        public KasaVirmanManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<KasaVirman>> Get(int id)
        {
            var entity = await _unitOfWork.KasaVirmans.GetAsync(c => c.Id == id);
            if (entity != null)
            {
                return new DataResult<KasaVirman>(ResultStatus.Success, entity);
            }
            return new DataResult<KasaVirman>(ResultStatus.Error, "Kasa Virman Fişi Bulunamadı", null);
        }
        public async Task<IDataResult<IList<KasaVirman>>> GetAll()
        {
            var entities = await _unitOfWork.KasaVirmans.GetAllAsync(null,
                b => b.HedefKasaKart,
                c => c.KaynakKasaKart);
            if (entities.Count > -1)
            {
                return new DataResult<IList<KasaVirman>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<KasaVirman>>(ResultStatus.Error, "Kasa Virman Fişi Bulunamadı", null);
        }
        public async Task<IDataResult<IList<KasaVirman>>> GetAllByNonDeleted()
        {
            var entities = await _unitOfWork.KasaVirmans.GetAllAsync(
                b => !b.IsDeleted,
                b => b.HedefKasaKart,
                c => c.KaynakKasaKart);
            if (entities.Count > -1)
            {
                return new DataResult<IList<KasaVirman>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<KasaVirman>>(ResultStatus.Error, "Kasa Virman Fişi Bulunamadı", null);
        }
        public async Task<IResult> Add(KasaVirman kasaVirman)
        {
            kasaVirman.DeletedBy = null;
            kasaVirman.IsDeleted = false;
            kasaVirman.RecordDate = DateTime.Now;
            kasaVirman.SoftDeleteDate = null;
            kasaVirman.UpdateDate = DateTime.Now;

            await _unitOfWork.KasaVirmans.AddAsync(kasaVirman).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Kasa Virman Fişi başarıyla eklenmiştir.");
        }
        public async Task<IResult> Update(KasaVirman kasaVirman)
        {

            kasaVirman.DeletedBy = null;
            kasaVirman.IsDeleted = false;
            kasaVirman.RecordDate = DateTime.Now;
            kasaVirman.SoftDeleteDate = null;
            kasaVirman.UpdateDate = DateTime.Now;

            await _unitOfWork.KasaVirmans.UpdateAsync(kasaVirman).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Kasa Virman Fişi  başarıyla güncellenmiştir.");
        }
        public async Task<IResult> SoftDelete(int id)
        {
            var kasaVirman = await _unitOfWork.KasaVirmans.GetAsync(b => b.Id == id);
            await _unitOfWork.KasaVirmans.SoftDeleteAsync(kasaVirman).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Kasa Virman Fişi  başarıyla silinmiştir.");
        }
        public async Task<IResult> HardDelete(int id)
        {
            var kasaVirman = await _unitOfWork.KasaVirmans.GetAsync(b => b.Id == id);
            await _unitOfWork.KasaVirmans.HardDeleteAsync(kasaVirman).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Kasa Virman Fişi başarıyla Database'den silinmiştir.");
        }
    }
}
