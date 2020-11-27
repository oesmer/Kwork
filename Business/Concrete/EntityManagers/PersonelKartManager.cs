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
    public class PersonelKartManager:IPersonelKartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonelKartManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<PersonelKart>> Get(int id)
        {
            var entity = await _unitOfWork.PersonelKarts.GetAsync(c => c.Id == id);
            if (entity != null)
            {
                return new DataResult<PersonelKart>(ResultStatus.Success, entity);
            }
            return new DataResult<PersonelKart>(ResultStatus.Error, "Personel Kartı Bulunamadı", null);
        }
        public async Task<IDataResult<IList<PersonelKart>>> GetAll()
        {
            var entities = await _unitOfWork.PersonelKarts.GetAllAsync(null, b => b.AltPersonels, 
                c => c.Departman, x => x.MaasAvansDekont, d => d.UstPersonel);
            if (entities.Count > -1)
            {
                return new DataResult<IList<PersonelKart>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<PersonelKart>>(ResultStatus.Error, "Personel Kartı Bulunamadı", null);
        }
        public async Task<IDataResult<IList<PersonelKart>>> GetAllByNonDeleted()
        {
            var entities = await _unitOfWork.PersonelKarts.GetAllAsync(b => !b.IsDeleted, 
                b => b.AltPersonels,c=>c.Departman,x=>x.MaasAvansDekont,d=>d.UstPersonel);
            if (entities.Count > -1)
            {
                return new DataResult<IList<PersonelKart>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<PersonelKart>>(ResultStatus.Error, "Personel Kartı Bulunamadı", null);
        }
        public async Task<IResult> Add(PersonelKart personelKart)
        {
            personelKart.DeletedBy = null;
            personelKart.IsDeleted = false;
            personelKart.RecordDate = DateTime.Now;
            personelKart.SoftDeleteDate = null;
            personelKart.UpdateDate = DateTime.Now;

            await _unitOfWork.PersonelKarts.AddAsync(personelKart).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Personel Kartı başarıyla eklenmiştir.");
        }
        public async Task<IResult> Update(PersonelKart personelKart)
        {

            personelKart.DeletedBy = null;
            personelKart.IsDeleted = false;
            personelKart.RecordDate = DateTime.Now;
            personelKart.SoftDeleteDate = null;
            personelKart.UpdateDate = DateTime.Now;

            await _unitOfWork.PersonelKarts.UpdateAsync(personelKart).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Personel Kartı başarıyla güncellenmiştir.");
        }
        public async Task<IResult> SoftDelete(int id)
        {
            var personelKart = await _unitOfWork.PersonelKarts.GetAsync(b => b.Id == id);
            await _unitOfWork.PersonelKarts.SoftDeleteAsync(personelKart).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Personel Kartı başarıyla silinmiştir.");
        }
        public async Task<IResult> HardDelete(int id)
        {
            var personelKart = await _unitOfWork.PersonelKarts.GetAsync(b => b.Id == id);
            await _unitOfWork.PersonelKarts.HardDeleteAsync(personelKart).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Personel Kartı başarıyla Database'den silinmiştir.");
        }
    }
}
