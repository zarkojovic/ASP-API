using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Domain
{
    public class Deal : Entity
    {
        public string University {  get; set; }
        public string Degree { get; set; }
        public string Program { get; set; }
        public int StageId { get; set; }

        public virtual Stage Stage {  get; set; }

        public virtual ICollection<UserInfo> UserInfo { get; set; } = new HashSet<UserInfo>();
    }
}
