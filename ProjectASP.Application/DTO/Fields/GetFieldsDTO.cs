using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.DTO.Fields
{
    public class GetFieldsDTO
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public bool ReadOnly { get; set; }
        public bool Required { get; set; }
        public int? CategoryId { get; set; }
    }
}
