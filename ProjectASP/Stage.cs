using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Domain
{
    public class Stage : NamedEntity
    {
        public int? Order { get; set; }

        public virtual ICollection<Deal> Deals { get; set; } = new HashSet<Deal>();

        public virtual ICollection<CategoryStage> Categories { get; set; } = new HashSet<CategoryStage>();
    }
}
