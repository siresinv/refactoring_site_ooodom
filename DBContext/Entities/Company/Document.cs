using System;

namespace Company.Entities
{
    public class Document
    {
        public Guid Id { get; set; }
        public Guid DocumentTypeId { get; set; }
        public virtual DocumentType Type { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Version { get; set; }
        public string StorageLink { get; set; }


        public UnitDocument UnitDocument { get; set; }


        /*public Company Company { get; set; }
        public Guid CompanyId { get; set; }*/
    }
} 