using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.DTO.Pages
{
    public class CreatePageDTO
    {
        public string Route { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string Icon { get; set; }
        public List<int>? PackageIds { get; set; }
    }
}
