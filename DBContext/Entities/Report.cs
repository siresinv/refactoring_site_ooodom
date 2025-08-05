using System;
using System.Collections.Generic;

namespace DBContext.Entities
{
    public class Report
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string NickName { get; set; } = null!;
        public virtual ICollection<DocumentType> DocumentTypes { get; set; } = null!;

        /*public Report()
        {
            DocumentTypes = new List<DocumentType>();
        }*/
    }
} 