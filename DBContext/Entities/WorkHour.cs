using System;

namespace DBContext.Entities
{
    public class WorkHour
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;


        public Guid CompanyCardId { get; set; }
        public CompanyCard CompanyCard { get; set; } = null!;
    }
} 