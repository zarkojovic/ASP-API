using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Domain
{
    public class Notification : Entity
    {
        public string Message { get; set; }
        public int UserId { get; set; }
        public bool IsRead { get; set; }
        public virtual User User { get; set; }

    }
}
