using ProjectASP.Application.DTO.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.DTO.Categories
{
    public class FindCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetFieldsDTO> Fields { get; set; }
    }
}
