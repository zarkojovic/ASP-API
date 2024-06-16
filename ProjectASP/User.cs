using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Domain
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public int PackageId { get; set; }
        public int? CompanyId { get; set; }
        public virtual Role Role { get; set; }
        public virtual User Company { get; set; }
        public virtual Package Package { get; set; }
        public virtual ICollection<UserInfo> UserInfo { get; set; } = new HashSet<UserInfo>();
        public virtual ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        public virtual ICollection<User> Students { get; set; } = new HashSet<User>();
    }
}
