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
    public class KasaKartManager:IKasaKartService
    {
        private readonly UnitOfWork _unitOfWork;
        public KasaKartManager(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<KasaKart>> Get(int id)
        {
            var entity = await _unitOfWork.KasaKarts.GetAsync(c => c.Id == id);
            if (entity != null)
            {
                return new DataResult<KasaKart>(ResultStatus.Success, entity);
            }
            return new DataResult<KasaKart>(ResultStatus.Error, "Departman Kartı Bulunamadı", null);
        }
        public async Task<IDataResult<IList<KasaKart>>> GetAll()
        {
            var entities = await _unitOfWork.KasaKarts.GetAllAsync(null, b => !b.IsDeleted,
                b => b.MaasAvansDekont,
                c => c.MasrafDekont,
                d => d.TahsilDekont,
                t => t.TediyeDekont);
            if (entities.Count > -1)
            {
                return new DataResult<IList<KasaKart>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<KasaKart>>(ResultStatus.Error, "Kasa Kart Bulunamadı", null);
        }
        public async Task<IDataResult<IList<KasaKart>>> GetAllByNonDeleted()
        {
            var entities = await _unitOfWork.KasaKarts.GetAllAsync(
                b => !b.IsDeleted, 
                b => b.MaasAvansDekont,
                c=>c.MasrafDekont,
                d=>d.TahsilDekont,
                t=>t.TediyeDekont);
            if (entities.Count > -1)
            {
                return new DataResult<IList<KasaKart>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<KasaKart>>(ResultStatus.Error, "Kasa Kart Bulunamadı", null);
        }
        public async Task<IResult> Add(KasaKart kasaKart)
        {
            kasaKart.DeletedBy = null;
            kasaKart.IsDeleted = false;
            kasaKart.RecordDate = DateTime.Now;
            kasaKart.SoftDeleteDate = null;
            kasaKart.UpdateDate = DateTime.Now;

            await _unitOfWork.KasaKarts.AddAsync(kasaKart).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{kasaKart.KasaAdi} başarıyla eklenmiştir.");
        }
        public async Task<IResult> Update(KasaKart kasaKart)
        {

            kasaKart.DeletedBy = null;
            kasaKart.IsDeleted = false;
            kasaKart.RecordDate = DateTime.Now;
            kasaKart.SoftDeleteDate = null;
            kasaKart.UpdateDate = DateTime.Now;

            await _unitOfWork.KasaKarts.UpdateAsync(kasaKart).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{kasaKart.KasaAdi} başarıyla güncellenmiştir.");
        }
        public async Task<IResult> SoftDelete(int id)
        {
            var kasaKart = await _unitOfWork.KasaKarts.GetAsync(b => b.Id == id);
            await _unitOfWork.KasaKarts.SoftDeleteAsync(kasaKart).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{kasaKart.KasaAdi} başarıyla silinmiştir.");
        }
        public async Task<IResult> HardDelete(int id)
        {
            var kasaKart = await _unitOfWork.KasaKarts.GetAsync(b => b.Id == id);
            await _unitOfWork.KasaKarts.HardDeleteAsync(kasaKart).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{kasaKart.KasaAdi} başarıyla Database'den silinmiştir.");
        }
    }
}
