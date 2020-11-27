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
    public class BirimKartManager : IBirimKartService
    {
        private readonly UnitOfWork _unitOfWork;
        public BirimKartManager(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<BirimKart>> Get(int id)
        {
            var entity = await _unitOfWork.BirimKarts.GetAsync(c => c.Id == id,a=>a.MasrafDekonts);
            if (entity != null)
            {
                return new DataResult<BirimKart>(ResultStatus.Success, entity);
            }
            return new DataResult<BirimKart>(ResultStatus.Error, "Birim Kartı Bulunamadı", null);
        }
        public async Task<IDataResult<IList<BirimKart>>> GetAll()
        {
            var entities = await _unitOfWork.BirimKarts.GetAllAsync(null, b => b.MasrafDekonts);
            if (entities.Count > -1)
            {
                return new DataResult<IList<BirimKart>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<BirimKart>>(ResultStatus.Error, "Birim Kart Bulunamadı", null);
        }
        public async Task<IDataResult<IList<BirimKart>>> GetAllByNonDeleted()
        {
            var entities = await _unitOfWork.BirimKarts.GetAllAsync(b => !b.IsDeleted, b => b.MasrafDekonts);
            if (entities.Count > -1)
            {
                return new DataResult<IList<BirimKart>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<BirimKart>>(ResultStatus.Error, "Birim Kart Bulunamadı", null);
        }
        public async Task<IResult> Add(BirimKart birimKart)
        {
            birimKart.DeletedBy = null;
            birimKart.IsDeleted = false;
            birimKart.RecordDate = DateTime.Now;
            birimKart.SoftDeleteDate = null;
            birimKart.UpdateDate = DateTime.Now;

            await _unitOfWork.BirimKarts.AddAsync(birimKart).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{birimKart.BirimAdi} başarıyla eklenmiştir.");
        }
        public async Task<IResult> Update(BirimKart birimKart)
        {
           
            birimKart.DeletedBy = null;
            birimKart.IsDeleted = false;
            birimKart.RecordDate = DateTime.Now;
            birimKart.SoftDeleteDate = null;
            birimKart.UpdateDate = DateTime.Now;

            await _unitOfWork.BirimKarts.UpdateAsync(birimKart).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{birimKart.BirimAdi} başarıyla güncellenmiştir.");
        }
        public async Task<IResult> SoftDelete(int id)
        {
            var birimKart = await _unitOfWork.BirimKarts.GetAsync(b => b.Id == id);
            await _unitOfWork.BirimKarts.SoftDeleteAsync(birimKart).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{birimKart.BirimAdi} başarıyla silinmiştir.");
        }
        public async Task<IResult> HardDelete(int id)
        {
            var birimKart = await _unitOfWork.BirimKarts.GetAsync(b => b.Id == id);
            await _unitOfWork.BirimKarts.HardDeleteAsync(birimKart).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{birimKart.BirimAdi} başarıyla Database'den silinmiştir.");
        }
    }
}
