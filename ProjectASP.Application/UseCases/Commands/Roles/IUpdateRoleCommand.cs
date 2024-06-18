using ProjectASP.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.UseCases.Commands.Roles
{
    public interface IUpdateRoleCommand : ICommand<LookupEntityDTO>
    {
    }
}
