﻿namespace Khayati.Core.Domain.Entities
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }

        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }

        public bool IsDeleted { get; set; }
    }

}
