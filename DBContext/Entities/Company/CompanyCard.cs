using System;
using System.Collections.Generic;

namespace Company.Entities
{
    public class CompanyCard
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string DirectorFullName { get; set; }
        public string Url { get; set; }
        public string Post { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public virtual ICollection<WorkHour> WorkHours { get; set; }
        public virtual ICollection<Reception> Receptions { get; set; }
        //public virtual ICollection<Document> Documents { get; set; }
        public string LocationLink { get; set; }


        public Company Company { get; set; }
        public Guid CompanyId { get; set; }

        public CompanyCard()
        {
            Phones = new List<Phone>();
            WorkHours = new List<WorkHour>();
            Receptions = new List<Reception>();
            //Documents = new List<Document>();
        }
    }
} 