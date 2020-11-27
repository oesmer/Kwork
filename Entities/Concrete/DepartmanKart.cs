using Kwork.Core.Entities.Abstract;
using System.Collections.Generic;

namespace Kwork.Entities.Concrete
{
    public class DepartmanKart : BaseEntity, IEntity
    {
        public string DepartmanAdi { get; set; }
        public virtual ICollection<PersonelKart> Personel { get; set; }
    }
}
