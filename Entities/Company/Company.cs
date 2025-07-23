using System;
using System.Collections.Generic;

namespace Company.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public virtual ICollection<Unit> Units { get; set; }

        public Company()
        {
            Units = new List<Unit>();
        }
    }
} 