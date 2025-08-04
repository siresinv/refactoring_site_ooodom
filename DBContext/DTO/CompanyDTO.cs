using System;
using System.Collections.Generic;

namespace DBContext.DTO
{
    public class CompanyDTO
    {
        public Guid Id { get; set; }
        public List<Guid> UnitIds { get; set; }
    }
} 