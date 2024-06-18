using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using ProjectASP.Application.DTO.Users;
using ProjectASP.Application.UseCases.Commands.Users;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using ProjectASP.Implementation.Validations.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Users
{
    public class EfUpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        private readonly AspContext _context;
        private readonly UpdateUserValidator _validator;
        public EfUpdateUserCommand(AspContext context, UpdateUserValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 8;

        public string Name => "UpdateUserCommand";

        public void Execute(UpdateUserDTO data)
        {
            _validator.ValidateAndThrow(data);

            User user = _context.Users.Find(data.Id);

            if (!data.Username.IsNullOrEmpty())
            {
                user.Username = data.Username;
            }

            if (!data.Email.IsNullOrEmpty())
            {
                user.Email = data.Email;
            }

            if (!data.FirstName.IsNullOrEmpty())
            {
                user.FirstName = data.FirstName;
            }

            if (!data.LastName.IsNullOrEmpty())
            {
                user.LastName = data.LastName;
            }

            if (!data.Phone.IsNullOrEmpty())
            {
                user.Phone = data.Phone;
            }

            if (!data.Password.IsNullOrEmpty())
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(data.Password);
            }

            if (data.RoleId.HasValue)
            {
                user.RoleId = data.RoleId.Value;
            }

            if (data.PackageId.HasValue)
            {
                user.PackageId = data.PackageId.Value;
            }

            _context.SaveChanges();

        }
    }
}
