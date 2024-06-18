using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.DTO.Categories
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int>? PageIds { get; set; }
        public List<int>? StageIds { get; set; }
        public List<int>? FieldIds { get; set; }
    }
}
