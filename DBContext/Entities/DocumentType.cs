using System;
using System.Collections.Generic;

namespace DBContext.Entities
{
    public class DocumentType
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string NickName { get; set; } = null!;
        public virtual ICollection<Report> Reports { get; set; } = null!;
        public virtual ICollection<Document>? Documents { get; set; }

       /* public DocumentType()
        {
            Documents = new List<Document>();
            Reports = new List<Report>();
        }*/
    }
} 