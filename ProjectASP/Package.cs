using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Domain
{
    public class Package : NamedEntity
    {
        public virtual ICollection<Page> Pages {  get; set; } = new HashSet<Page>();
        public virtual ICollection<User> Users {  get; set; } = new HashSet<User>();
    }
}
