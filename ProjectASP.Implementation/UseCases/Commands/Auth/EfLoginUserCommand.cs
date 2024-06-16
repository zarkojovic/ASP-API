using ProjectASP.Application.DTO.Auth;
using ProjectASP.Application.UseCases.Commands.Auth;
using ProjectASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Auth
{
    public class EfLoginUserCommand : EfUseCase, ILoginUserCommand
    {
        public EfLoginUserCommand(AspContext context) : base(context)
        {
        }

        public int Id => 2;

        public string Name => "LoginUserCommand";

        public void Execute(LoginUserDTO data)
        {
            throw new NotImplementedException();
        }
    }
}
