using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Common.Entities
{
    public abstract class BaseEntity<TKey>
    {
        public required TKey Id { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public required string LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
