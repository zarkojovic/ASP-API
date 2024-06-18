using ProjectASP.Application.DTO;
using ProjectASP.Application.UseCases.Commands.Roles;
using ProjectASP.DataAccess;
using ProjectASP.Implementation.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Roles
{
    public class EfUpdateRoleCommand : EfUseCase, IUpdateRoleCommand
    {
        private readonly AspContext _context;
        private readonly LookupEntityValidator _validator;
        public EfUpdateRoleCommand(AspContext context, LookupEntityValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "UpdateRoleCommand";

        public void Execute(LookupEntityDTO data)
        {
            throw new NotImplementedException();
        }
    }
}
