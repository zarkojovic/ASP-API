using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Domain
{
    public class FieldItem : NamedEntity
    {
        public int FieldId { get; set; }
        public string Value { get; set; }
        public virtual Field Field { get; set; }
    }
}
