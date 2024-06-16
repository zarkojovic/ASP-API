using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Domain
{
    public class Page : NamedEntity
    {
        public string Route { get; set; }
        public string Icon { get; set; }
        public int RoleId { get; set; }
        public int? Order {  get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<PackagePage> Packages { get; set; } = new HashSet<PackagePage>();
        public virtual ICollection<Category> Categories {  get; set; } = new HashSet<Category>();
    }
}
