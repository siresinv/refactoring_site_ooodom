using System;
using System.Collections.Generic;

namespace webapi.DTO
{
    public class UnitDTO
    {
        public Guid Id { get; set; }
        public List<Guid> DocumentIds { get; set; }
    }
} 