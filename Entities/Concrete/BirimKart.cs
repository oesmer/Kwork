using Kwork.Core.Entities.Abstract;
using System.Collections.Generic;

namespace Kwork.Entities.Concrete
{
    public class BirimKart : BaseEntity, IEntity
    {
        public string BirimAdi { get; set; }
        public virtual ICollection<MasrafDekont> MasrafDekonts { get; set; }
    }
}
