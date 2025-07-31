using System;
using System.Collections.Generic;

namespace Company.Entities
{
    public class Unit
    {
        public Guid Id { get; set; }
        public virtual ICollection<UnitDocument> Documents { get; set; }



        public UnitCard Card { get; set; }
        public Unit()
        {
            Documents = new List<UnitDocument>();
        }
    }
} 