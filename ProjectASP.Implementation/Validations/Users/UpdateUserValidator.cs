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
    public class UpdateUserValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserValidator(AspContext context)
        {
            RuleFor(x => x.Username)
                .Must((dto, username) => !context.Users.Any(u => u.Username == username && u.Id != dto.Id))
                .When(x => !string.IsNullOrWhiteSpace(x.Username))
                .WithMessage(dto => $"Username {dto.Username} is already taken.");


            RuleFor(x => x.Email)
                .Must((dto, email) => !context.Users.Any(u => u.Email == email && u.Id != dto.Id))
                .When(x => !string.IsNullOrWhiteSpace(x.Email))
                .WithMessage(dto => $"Email {dto.Email} is already taken.");

            RuleFor(x => x.Phone)
                .Must((dto, phone) => !context.Users.Any(u => u.Phone == phone && u.Id != dto.Id))
                .When(x => !string.IsNullOrWhiteSpace(x.Phone))
                .WithMessage(dto => $"Phone number {dto.Phone} is already taken.");

            RuleFor(x => x.Password)
                .Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$")
                .When(x => !string.IsNullOrWhiteSpace(x.Phone))
                .WithMessage("Password must contain 8 characters, one letter and one number.");

            RuleFor(x => x.Phone)
                .Matches("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$")
                .When(x => !string.IsNullOrWhiteSpace(x.Phone))
                .WithMessage("Phone number can only contain numbers.");

            RuleFor(x => x.RoleId)
                .Must(x => context.Roles.Any(r => r.Id == x))
                .When(x => x.RoleId != null)
                .WithMessage("Role does not exist in database.");

            RuleFor(x => x.PackageId)
                .Must(x => context.Packages.Any(p => p.Id == x))
                .When(x => x.PackageId != null)
                .WithMessage("Package does not exist in database.");

        }
    }
}
