using System;
using System.Collections.Generic;

namespace DBContext.DTO
{
    public class CompanyCardDTO
    {
        public Guid Id { get; set; }
        public string DirectorFullName { get; set; } = null!;
        public string CertificateGRUL { get; set; } = null!;
        public string Post { get; set; } = null!;
        public string Address { get; set; } = null!;
        public List<Guid> PhoneIds { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Site { get; set; } = null!;
        public List<Guid> WorkHourIds { get; set; } = null!;
        public List<Guid> ReceptionIds { get; set; } = null!;
        public List<Guid>? DocumentIds { get; set; }
        public string? LocationLink { get; set; }
    }
} 