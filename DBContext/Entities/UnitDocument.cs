using System;

namespace DBContext.Entities
{
    public class UnitDocument
    {
        public Guid Id { get; set; }
        //public Guid UnitId { get; set; }
        public Guid DocumentId { get; set; }
        public Document Document { get; set; }


        public Guid UnitId { get; set; }
        public virtual Unit Unit { get; set; }
    }
} 