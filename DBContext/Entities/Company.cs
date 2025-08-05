using System;
using System.Collections.Generic;

namespace DBContext.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Shortname { get; set; } = null!;


        public virtual ICollection<Unit>? Units { get; set; }

        public CompanyCard? CompanyCard { get; set; }

        public virtual ICollection<Document>? Documents { get; set; }
        /*public Company()
        {
            Units = new List<Unit>();
        }*/
    }
} 