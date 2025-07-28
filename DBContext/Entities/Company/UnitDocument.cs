using System;

namespace Company.Entities
{
    public class UnitDocument
    {
        public Guid Id { get; set; }
        public Guid UnitId { get; set; }
        public Guid DocumentId { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual Document Document { get; set; }
    }
} 