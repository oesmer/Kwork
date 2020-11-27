using Kwork.Core.Entities.Abstract;
using System.Collections.Generic;

namespace Kwork.Entities.Concrete
{
    public class KDV : BaseEntity, IEntity
    {
        public int KDVOrani { get; set; }
        public virtual ICollection<MasrafDekont> MasrafDekont { get; set; }
    }
}
