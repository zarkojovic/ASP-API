using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.DTO.Fields
{
    public class SearchFieldsDTO : PagedSearch
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsReadOnly { get; set; }
        public int? CategoryId { get; set; }

    }
}
