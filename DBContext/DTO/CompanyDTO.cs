using System;
using System.Collections.Generic;

namespace DBContext.DTO
{
    public class CompanyDTO
    {
        //public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Shortname { get; set; } = null!;
        public CompanyCardDTO CompanyCard { get; set; } = null!;

    }
} 