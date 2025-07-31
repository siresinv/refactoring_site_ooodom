using System;
using System.Collections.Generic;

namespace Company.Entities
{
    public class Unit
    {
        public Guid Id { get; set; }
        public virtual ICollection<Document> Documents { get; set; }

        public UnitCard Card { get; set; }
        public Unit()
        {
            Documents = new List<Document>();
        }
    }
} 