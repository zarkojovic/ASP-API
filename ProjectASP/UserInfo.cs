using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Domain
{
    public class UserInfo : Entity
    {
        public int UserId { get; set; }
        public int FieldId { get; set; }
        public string? Value { get; set; }
        public string? DisplayValue { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public virtual User User { get; set; }
        public virtual Field Field { get; set; }
    }
}
