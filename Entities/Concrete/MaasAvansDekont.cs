using Kwork.Core.Entities.Abstract;
using System;

namespace Kwork.Entities.Concrete
{
    public class MaasAvansDekont : BaseEntity, IEntity
    {
        public DateTime DekontTarihi { get; set; }
        public decimal Tutar { get; set; }
        public int PersonelID { get; set; }
        public int KasaKartID { get; set; }
        public decimal KasaBakiye { get; set; }
        public decimal PersonelBakiye { get; set; }
        public string Aciklama { get; set; }
        public virtual KasaKart KasaKart { get; set; }
        public virtual PersonelKart Personel { get; set; }
    }
}
