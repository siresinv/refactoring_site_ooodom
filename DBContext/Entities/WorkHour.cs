using System;

namespace DBContext.Entities
{
    public class WorkHour
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
} 