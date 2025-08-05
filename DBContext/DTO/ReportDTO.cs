using System;
using System.Collections.Generic;

namespace DBContext.DTO
{
    public class ReportDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string NickName { get; set; } = null!;
        public List<Guid> DocumentTypeIds { get; set; } = null!;
    }
} 