using llbltest.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace llbltest.Dtos
{
    public class DealerDto
    {
        public int Id { get; set; }
        public string DealerName { get; set; }
        public int? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual List<Salesman> Salesmen { get; set; }
    }
}
