using System;
using System.Collections.Generic;

namespace DBContext.DTO
{
    public class UnitDTO
    {
        public Guid Id { get; set; }
        public List<Guid> DocumentIds { get; set; }
    }
} 