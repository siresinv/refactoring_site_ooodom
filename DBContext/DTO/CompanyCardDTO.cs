using System;
using System.Collections.Generic;

namespace DBContext.DTO
{
    public class CompanyCardDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string DirectorFullName { get; set; }
        public string Url { get; set; }
        public string Post { get; set; }
        public string Address { get; set; }
        public List<Guid> PhoneIds { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public List<Guid> WorkHourIds { get; set; }
        public List<Guid> ReceptionIds { get; set; }
        public List<Guid> DocumentIds { get; set; }
        public string LocationLink { get; set; }
    }
} 