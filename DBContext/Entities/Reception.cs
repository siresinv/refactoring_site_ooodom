using System;

namespace DBContext.Entities
{
    public class Reception
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
} 