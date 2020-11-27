using Kwork.Core.Entities.Abstract;
using System.Collections.Generic;

namespace Kwork.Entities.Concrete
{
    public class KasaKart : BaseEntity, IEntity
    {
        public string KasaAdi { get; set; }
        public string Aciklama { get; set; }
        public decimal KasaBakiye { get; set; } = 0;
        public virtual ICollection<TediyeDekont> TediyeDekont { get; set; }
        public virtual ICollection<TahsilDekont> TahsilDekont { get; set; }
        public virtual ICollection<KasaVirman> KaynakKasa { get; set; }
        public virtual ICollection<KasaVirman> HedefKasa { get; set; }
        public virtual ICollection<MaasAvansDekont> MaasAvansDekont { get; set; }
        public virtual ICollection<MasrafDekont> MasrafDekont { get; set; }
    }
}
