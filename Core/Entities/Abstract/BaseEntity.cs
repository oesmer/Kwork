using System;
using System.Collections.Generic;
using System.Text;

namespace Kwork.Core.Entities.Abstract
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public virtual DateTime RecordDate { get; set; } = DateTime.Now;
        public virtual DateTime? UpdateDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public int? DeletedBy { get; set; }
        public DateTime? SoftDeleteDate { get; set; }
    }
}
