using System;
using System.Collections.Generic;

namespace DBContext.DTO
{
    public class DocumentTypeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string NickName { get; set; } = null!;    
        public List<Guid>? DocumentIds { get; set; }
    }
} 