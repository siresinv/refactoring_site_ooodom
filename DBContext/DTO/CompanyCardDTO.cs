using System;
using System.Collections.Generic;

namespace DBContext.DTO
{
    public class CompanyCardDTO
    {
        //public Guid Id { get; set; }
        public string DirectorFullName { get; set; } = null!;
        public string SertificateGRUL { get; set; } = null!;
        public string Post { get; set; } = null!;
        public string Address { get; set; } = null!;
        public List<PhoneDTO> Phones { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Site { get; set; } = null!;
        public List<WorkHourDTO> WorkHours { get; set; } = null!;
        public List<ReceptionDTO> Receptions { get; set; } = null!;
        //public List<Guid>? DocumentIds { get; set; }
        public string? LocationLink { get; set; }
    }
} 