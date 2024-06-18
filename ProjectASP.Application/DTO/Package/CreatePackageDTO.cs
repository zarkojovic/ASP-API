using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.DTO.Package
{
    public class CreatePackageDTO
    {
        public string Name { get; set; }
        public List<int>? PageIds { get; set; }
    }
}
