using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Domain
{
    public class Category : NamedEntity
    {
        public bool ReadOnly { get; set; }
        public virtual ICollection<Page> Pages { get; set; } = new HashSet<Page>();
        public virtual ICollection<Stage> Stages { get; set; } = new HashSet<Stage>();
        public virtual ICollection<Field> Fields { get; set; } = new HashSet<Field>();
    }
}
