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
    public class DepartmanKartManager:IDepartmanKartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmanKartManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<DepartmanKart>> Get(int id)
        {
            var entity = await _unitOfWork.DepartmanKarts.GetAsync(c => c.Id == id);
            if (entity != null)
            {
                return new DataResult<DepartmanKart>(ResultStatus.Success, entity);
            }
            return new DataResult<DepartmanKart>(ResultStatus.Error, "Departman Kartı Bulunamadı", null);
        }
        public async Task<IDataResult<IList<DepartmanKart>>> GetAll()
        {
            var entities = await _unitOfWork.DepartmanKarts.GetAllAsync(null, b => b.Personel);
            if (entities.Count > -1)
            {
                return new DataResult<IList<DepartmanKart>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<DepartmanKart>>(ResultStatus.Error, "Departman Kart Bulunamadı", null);
        }
        public async Task<IDataResult<IList<DepartmanKart>>> GetAllByNonDeleted()
        {
            var entities = await _unitOfWork.DepartmanKarts.GetAllAsync(b => !b.IsDeleted, b => b.Personel);
            if (entities.Count > -1)
            {
                return new DataResult<IList<DepartmanKart>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<DepartmanKart>>(ResultStatus.Error, "Departman Kart Bulunamadı", null);
        }
        public async Task<IResult> Add(DepartmanKart departmanKart)
        {
            departmanKart.DeletedBy = null;
            departmanKart.IsDeleted = false;
            departmanKart.RecordDate = DateTime.Now;
            departmanKart.SoftDeleteDate = null;
            departmanKart.UpdateDate = DateTime.Now;

            await _unitOfWork.DepartmanKarts.AddAsync(departmanKart).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{departmanKart.DepartmanAdi} başarıyla eklenmiştir.");
        }
        public async Task<IResult> Update(DepartmanKart departmanKart)
        {

            departmanKart.DeletedBy = null;
            departmanKart.IsDeleted = false;
            departmanKart.RecordDate = DateTime.Now;
            departmanKart.SoftDeleteDate = null;
            departmanKart.UpdateDate = DateTime.Now;

            await _unitOfWork.DepartmanKarts.UpdateAsync(departmanKart).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{departmanKart.DepartmanAdi} başarıyla güncellenmiştir.");
        }
        public async Task<IResult> SoftDelete(int id)
        {
            var departmanKart = await _unitOfWork.DepartmanKarts.GetAsync(b => b.Id == id);
            await _unitOfWork.DepartmanKarts.SoftDeleteAsync(departmanKart).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{departmanKart.DepartmanAdi} başarıyla silinmiştir.");
        }
        public async Task<IResult> HardDelete(int id)
        {
            var departmanKart = await _unitOfWork.DepartmanKarts.GetAsync(b => b.Id == id);
            await _unitOfWork.DepartmanKarts.HardDeleteAsync(departmanKart).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{departmanKart.DepartmanAdi} başarıyla Database'den silinmiştir.");
        }
    }
}
