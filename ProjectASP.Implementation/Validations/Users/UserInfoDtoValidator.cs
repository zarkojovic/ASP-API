using FluentValidation;
using ProjectASP.Application.DTO.Users;
using ProjectASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.Validations.Users
{
    public class UserInfoDtoValidator : AbstractValidator<UserInfoDTO>
    {
        public readonly AspContext _context;
        public UserInfoDtoValidator(AspContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

        }
    }
}
