using llbltest.EntityClasses;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace llbltest.Dtos
{
    public class DealerDto
    {
        public int Id { get; set; }
        public string DealerName { get; set; }
        public int? OwnerId { get; set; }
        public IFormFile Attachment { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual List<Salesman> Salesmen { get; set; }
    }
}
