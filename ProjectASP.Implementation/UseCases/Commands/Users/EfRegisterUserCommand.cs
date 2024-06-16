using BCrypt.Net;
using FluentValidation;
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
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        
        public int Id => 1;

        public string Name => "UserRegistration";

        private readonly AspContext _context;
        private RegisterUserDtoValidator _validator;
        public EfRegisterUserCommand(AspContext context, RegisterUserDtoValidator validator) : base(context)
        {
            _validator = validator;
            _context = context;
        }

        public void Execute(RegisterUserDTO data)
        {
            this._validator.ValidateAndThrow(data);

            User newUser = new()
            {
                Username = data.Username,
                Email = data.Email,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
                ProfileImage = "default.jpg",
                Phone = data.Phone,
                Role = _context.Roles.FirstOrDefault(r => r.Name == "User"),
            };

            _context.Users.Add(newUser);

            _context.SaveChanges();

        }
    }
}
