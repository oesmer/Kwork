using Kwork.Core.Entities.Abstract;
using System.Collections.Generic;

namespace Kwork.Entities.Concrete
{ 
    public class CariKart : BaseEntity, IEntity
    {
        public string CariAdi { get; set; }
        public string CariSoyadi { get; set; }
        public string FirmaAdi { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNo { get; set; }
        public string Adres { get; set; }
        public decimal CariBakiye { get; set; }
        public virtual ICollection<TediyeDekont> TediyeDekont { get; set; }
        public virtual ICollection<TahsilDekont> TahsilDekont { get; set; }
    }
}
