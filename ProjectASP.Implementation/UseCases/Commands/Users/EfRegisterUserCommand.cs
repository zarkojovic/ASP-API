using BCrypt.Net;
using FluentValidation;
using ProjectASP.Application.DTO.Auth;
using ProjectASP.Application.DTO.Users;
using ProjectASP.Application.UseCases.Commands.Auth;
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
        private IEmailServiceProvider _emailService;
        public EfRegisterUserCommand(AspContext context, RegisterUserDtoValidator validator, IEmailServiceProvider emailService) : base(context)
        {
            _validator = validator;
            _context = context;
            _emailService = emailService;
        }

        public void Execute(RegisterUserDTO data)
        {
            this._validator.ValidateAndThrow(data);

            string defualtImage = "default.jpg";
            string defaultRole = "User";
            string defaultPackage = "Bronz";

            User newUser = new()
            {
                Username = data.Username,
                Email = data.Email,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
                ProfileImage = defualtImage,
                Phone = data.Phone,
                Role = _context.Roles.FirstOrDefault(r => r.Name == defaultRole),
                Package = _context.Packages.FirstOrDefault(x => x.Name == defaultPackage)
            };

            _context.Users.Add(newUser);

            _context.SaveChanges();

            _emailService.SendEmail(new SendEmailDTO
            {
                Content = "Welcome to our platform",
                Email = data.Email,
                Subject = "Welcome"
            });


        }
    }
}
