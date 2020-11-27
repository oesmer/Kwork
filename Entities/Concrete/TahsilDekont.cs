using Kwork.Core.Entities.Abstract;
using System;

namespace Kwork.Entities.Concrete
{
    public class TahsilDekont : BaseEntity, IEntity
    {
        public DateTime DekontTarihi { get; set; }
        public decimal Tutar { get; set; }
        public int CariID { get; set; }
        public int KasaKartID { get; set; }
        public decimal CariBakiye { get; set; }
        public decimal KasaBakiye { get; set; }
        public string Aciklama { get; set; }
        public string MakbuzNo { get; set; }
        public virtual CariKart CariKart { get; set; }
        public virtual KasaKart KasaKart { get; set; }
    }
}
