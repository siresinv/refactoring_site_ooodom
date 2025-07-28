using System;

namespace webapi.DTO
{
    public class DocumentDTO
    {
        public Guid Id { get; set; }
        public Guid DocumentTypeId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Version { get; set; }
        public string StorageLink { get; set; }
    }
} 