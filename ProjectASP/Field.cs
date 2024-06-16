using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Domain
{
    public class Field : NamedEntity
    {
        public bool IsRequired { get; set; }
        public bool IsReadOnly {  get; set; }
        public string Type {  get; set; }
        public string FieldKey {  get; set; }
        public int? Order {  get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<FieldItem> Items { get; set; } = new HashSet<FieldItem>();
        public virtual ICollection<UserInfo> UserInfo { get; set; } = new HashSet<UserInfo>();
        
    }
}
