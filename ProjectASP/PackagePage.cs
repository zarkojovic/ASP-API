using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Domain
{
    public class PackagePage
    {
        public int PackageId { get; set; }
        public int PageId { get; set; }
        public virtual Package Package { get; set; }
        public virtual Page Page { get; set; }
    }
}
