using Kwork.Core.Entities.Abstract;
using System.Collections.Generic;

namespace Kwork.Entities.Concrete
{
    public class Role : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
