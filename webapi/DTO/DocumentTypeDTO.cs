using System;
using System.Collections.Generic;

namespace webapi.DTO
{
    public class DocumentTypeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public List<Guid> DocumentIds { get; set; }
    }
} 