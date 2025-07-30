using System;
using System.Collections.Generic;

namespace Company.Entities
{
    public class DocumentType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Document> Documents { get; set; }

        public DocumentType()
        {
            Documents = new List<Document>();
            Reports = new List<Report>();
        }
    }
} 