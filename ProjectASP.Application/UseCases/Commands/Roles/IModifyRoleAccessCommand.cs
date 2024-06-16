using ProjectASP.Application.DTO.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.UseCases.Commands.Roles
{
    public interface IModifyRoleAccessCommand : ICommand<ModifyRoleAccessDTO>
    {
    }
}
