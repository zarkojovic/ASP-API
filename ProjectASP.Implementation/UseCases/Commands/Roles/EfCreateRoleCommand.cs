using FluentValidation;
using ProjectASP.Application.DTO;
using ProjectASP.Application.UseCases.Commands.Roles;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using ProjectASP.Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Roles
{
    public class EfCreateRoleCommand : EfUseCase, ICreateRoleCommand
    {
        private AspContext _context;
        private LookupEntityValidator _validator;
        public EfCreateRoleCommand(AspContext context, LookupEntityValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "CreateRole";

        public void Execute(LookupEntityDTO data)
        {
            _validator.ValidateAndThrow(data);

            _context.Roles.Add(new Role
            {
                Name = data.Name
            });

            _context.SaveChanges();
        }
    }
}
