using Kwork.Core.Entities.Abstract;
using System.Collections.Generic;

namespace Kwork.Entities.Concrete
{
    public class MasrafKart : BaseEntity, IEntity
    {
        public string MasrafAdi { get; set; }
        public virtual ICollection<MasrafDekont> MasrafDekont { get; set; }
    }
}
