using ProjectASP.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.UseCases.Commands.Users
{
    public interface IRegisterUserCommand : ICommand<RegisterUserDTO>
    {
    }
}
