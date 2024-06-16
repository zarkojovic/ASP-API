using ProjectASP.Application.DTO.Users;
using ProjectASP.Application.UseCases.Commands.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Users
{
    public class EfUserInfoCommand : IUserInfoCommand
    {
        public int Id => 4;

        public string Name => "NewUserInfo";

        public void Execute(UserInfoDTO data)
        {
            var test = 0;
        }
    }
}
