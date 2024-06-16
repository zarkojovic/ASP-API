using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Domain
{
    public class Role : NamedEntity
    {
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
        public virtual ICollection<RoleUseCase> UseCases { get; set; } = new HashSet<RoleUseCase>();
        public virtual ICollection<Page> Pages { get; set; } = new HashSet<Page>();
    }
}
