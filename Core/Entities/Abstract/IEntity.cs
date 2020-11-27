using System;
using System.Collections.Generic;
using System.Text;

namespace Kwork.Core.Entities.Abstract
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? SoftDeleteDate { get; set; }
    }
}
