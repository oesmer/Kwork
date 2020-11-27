using Kwork.Core.Entities.Abstract;
using System;

namespace Kwork.Entities.Concrete
{
    public class KasaVirman : BaseEntity, IEntity
    {
        public int KaynakKasaID { get; set; }
        public int HedefKasaID { get; set; }
        public decimal Tutar { get; set; }
        public DateTime DekontTarihi { get; set; }
        public string Aciklama { get; set; }
        public virtual KasaKart KaynakKasaKart { get; set; }
        public virtual KasaKart HedefKasaKart { get; set; }
    }
}
