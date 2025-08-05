using System;

namespace DBContext.DTO
{
    public class ReceptionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
} 