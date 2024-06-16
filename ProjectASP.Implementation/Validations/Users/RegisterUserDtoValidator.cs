using FluentValidation;
using ProjectASP.Application.DTO.Users;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.Validations.Users
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDTO>
    {
        private AspContext _context;
        public RegisterUserDtoValidator(AspContext asp)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            _context = asp;

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Email is not in the correct format.")
                .Must(email => !_context.Users.Any(c => c.Email == email))
                .WithMessage("Email is already taken.");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.")
                .MaximumLength(30)
                .WithMessage("First name can have a maximum of 30 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.")
                .MaximumLength(30)
                .WithMessage("Last name can have a maximum of 30 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .Matches("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$")
                .WithMessage("Phone number can only contain numbers.")
                .MinimumLength(9)
                .WithMessage("Phone number must have a minimum of 9 characters.")
                .MaximumLength(20)
                .WithMessage("Phone number can have a maximum of 15 characters.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$")
                .WithMessage("Password must contain 8 characters, one letter and one number.")
                .MinimumLength(8)
                .WithMessage("Password must have a minimum of 8 characters.");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required.")
                .MinimumLength(5)
                .WithMessage("Username must have a minimum of 5 characters.")
                .Matches("^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")
                .WithMessage("Username is not in the correct format.")
                .Must(username => !_context.Users.Any(c => c.Username == username))
                .WithMessage("Username is already taken.");

        }
    }
}
