using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.DTO.Roles
{
    public class ModifyRoleAccessDTO
    {
        public int RoleId { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; }
    }
}
