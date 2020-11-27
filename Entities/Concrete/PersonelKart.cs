using Kwork.Core.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Kwork.Entities.Concrete
{
    public class PersonelKart : BaseEntity, IEntity
    {
        public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }
        public string TCNo { get; set; }
        public string IBAN { get; set; }
        public string TelNo { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public int DepartmanID { get; set; }
        public decimal PersonelBakiye { get; set; } = 0;
        public int UstPersonelID { get; set; }
        public virtual PersonelKart UstPersonel { get; set; }
        public virtual DepartmanKart Departman { get; set; }
        public virtual ICollection<MaasAvansDekont> MaasAvansDekont { get; set; }
        public virtual ICollection<PersonelKart> AltPersonels { get; set; }
    }
}
