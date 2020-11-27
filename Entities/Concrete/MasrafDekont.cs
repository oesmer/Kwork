using Kwork.Core.Entities.Abstract;
using System;

namespace Kwork.Entities.Concrete
{
    public class MasrafDekont : BaseEntity, IEntity
    {
        public DateTime DekontTarihi { get; set; }
        public int MasrafKartID { get; set; }
        public int KasaKartID { get; set; }
        public decimal Miktar { get; set; }
        public int BirimKartID { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public int KDVID { get; set; }
        public decimal GenelToplam { get; set; }
        public string Aciklama { get; set; }
        public decimal KasaBakiye { get; set; }
        public virtual BirimKart BirimKart { get; set; }
        public virtual KasaKart KasaKart { get; set; }
        public virtual KDV KDV { get; set; }
        public virtual MasrafKart MasrafKart { get; set; }
    }
}
