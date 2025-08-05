using System;
using System.Collections.Generic;

namespace DBContext.Entities
{
    public class CompanyCard
    {
        public Guid Id { get; set; }

        public string DirectorFullName { get; set; } = null!;
        public string SertificateGRUL { get; set; } = null!;
        public string Post { get; set; } = null!;
        public string Address { get; set; } = null!;
        public virtual ICollection<Phone> Phones { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Site { get; set; } = null!;
        public virtual ICollection<WorkHour> WorkHours { get; set; } = null!;
        public virtual ICollection<Reception> Receptions { get; set; } = null!;
        public string? LocationLink { get; set; }


        public Company Company { get; set; } = null!;
        public Guid CompanyId { get; set; }

/*        public CompanyCard()
        {
            Phones = new List<Phone>();
            WorkHours = new List<WorkHour>();
            Receptions = new List<Reception>();
        }*/
    }
} 