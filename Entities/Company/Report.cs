using System;
using System.Collections.Generic;

namespace Company.Entities
{
    public class Report
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public virtual ICollection<DocumentType> DocumentTypes { get; set; }

        public Report()
        {
            DocumentTypes = new List<DocumentType>();
        }
    }
} 