using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Domain
{
    public class CategoryPage 
    {
        public int CategoryId { get; set; }
        public int PageId { get; set; }

        public virtual Page Page { get; set; }
        public virtual Category Category { get; set; }

    }
}
