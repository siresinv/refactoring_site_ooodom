using System;
using System.Collections.Generic;

namespace DBContext.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public virtual ICollection<Unit> Units { get; set; }

        public CompanyCard CompanyCard { get; set; }

        public ICollection<Document> Documents { get; set; }
        public Company()
        {
            Units = new List<Unit>();
        }
    }
} 