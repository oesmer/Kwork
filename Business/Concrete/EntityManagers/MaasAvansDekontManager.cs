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
    public class MaasAvansDekontManager:IMaasAvansDekontService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MaasAvansDekontManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<MaasAvansDekont>> Get(int id)
        {
            var entity = await _unitOfWork.MaasAvansDekonts.GetAsync(c => c.Id == id);
            if (entity != null)
            {
                return new DataResult<MaasAvansDekont>(ResultStatus.Success, entity);
            }
            return new DataResult<MaasAvansDekont>(ResultStatus.Error, "Dekont Bulunamadı", null);
        }
        public async Task<IDataResult<IList<MaasAvansDekont>>> GetAll()
        {
            var entities = await _unitOfWork.MaasAvansDekonts.GetAllAsync(null, b => b.Personel,c=>c.KasaKart);
            if (entities.Count > -1)
            {
                return new DataResult<IList<MaasAvansDekont>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<MaasAvansDekont>>(ResultStatus.Error, "Dekont Bulunamadı", null);
        }
        public async Task<IDataResult<IList<MaasAvansDekont>>> GetAllByNonDeleted()
        {
            var entities = await _unitOfWork.MaasAvansDekonts.GetAllAsync(b => !b.IsDeleted, b => b.Personel, c => c.KasaKart);
            if (entities.Count > -1)
            {
                return new DataResult<IList<MaasAvansDekont>>(ResultStatus.Success, entities);
            }
            return new DataResult<IList<MaasAvansDekont>>(ResultStatus.Error, "Dekont Bulunamadı", null);
        }
        public async Task<IResult> Add(MaasAvansDekont maasAvansDekont)
        {
            maasAvansDekont.DeletedBy = null;
            maasAvansDekont.IsDeleted = false;
            maasAvansDekont.RecordDate = DateTime.Now;
            maasAvansDekont.SoftDeleteDate = null;
            maasAvansDekont.UpdateDate = DateTime.Now;

            await _unitOfWork.MaasAvansDekonts.AddAsync(maasAvansDekont).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Dekont başarıyla eklenmiştir.");
        }
        public async Task<IResult> Update(MaasAvansDekont maasAvansDekont)
        {

            maasAvansDekont.DeletedBy = null;
            maasAvansDekont.IsDeleted = false;
            maasAvansDekont.RecordDate = DateTime.Now;
            maasAvansDekont.SoftDeleteDate = null;
            maasAvansDekont.UpdateDate = DateTime.Now;

            await _unitOfWork.MaasAvansDekonts.UpdateAsync(maasAvansDekont).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Dekont başarıyla güncellenmiştir.");
        }
        public async Task<IResult> SoftDelete(int id)
        {
            var maasAvansDekont = await _unitOfWork.MaasAvansDekonts.GetAsync(b => b.Id == id);
            await _unitOfWork.MaasAvansDekonts.SoftDeleteAsync(maasAvansDekont).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Dekont başarıyla silinmiştir.");
        }
        public async Task<IResult> HardDelete(int id)
        {
            var maasAvansDekont = await _unitOfWork.MaasAvansDekonts.GetAsync(b => b.Id == id);
            await _unitOfWork.MaasAvansDekonts.HardDeleteAsync(maasAvansDekont).ContinueWith(b => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, "Dekont başarıyla Database'den silinmiştir.");
        }
    }
}
