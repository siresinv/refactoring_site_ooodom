using System;

namespace DBContext.Entities
{
    public class Document
    {
        public Guid Id { get; set; }
        public Guid DocumentTypeId { get; set; }
        public DocumentType Type { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public int Version { get; set; }
        public string StorageLink { get; set; } = null!;


        public UnitDocument UnitDocument { get; set; } = null!;


        /*public Company Company { get; set; }
        public Guid CompanyId { get; set; }*/
    }
} 