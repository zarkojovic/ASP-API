using FluentValidation;
using ProjectASP.Application.DTO.Auth;
using ProjectASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.Validations.Auth
{
    public class LoginUserDtoValidator : AbstractValidator<LoginUserDTO>
    {
        private AspContext _context;
        public LoginUserDtoValidator(AspContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            _context = context;



        }



    }
}
