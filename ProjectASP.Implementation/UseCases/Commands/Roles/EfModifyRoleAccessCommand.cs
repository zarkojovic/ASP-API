using FluentValidation;
using ProjectASP.Application.DTO.Roles;
using ProjectASP.Application.UseCases.Commands.Roles;
using ProjectASP.DataAccess;
using ProjectASP.Implementation.Validations.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Roles
{
    public class EfModifyRoleAccessCommand : EfUseCase, IModifyRoleAccessCommand
    {

        private readonly ModifyRoleAccessValidator _validator;
        private readonly AspContext _context;

        public EfModifyRoleAccessCommand(AspContext context, ModifyRoleAccessValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "ModifyRoleAccess";

        public void Execute(ModifyRoleAccessDTO data)
        {

            _validator.ValidateAndThrow(data);

            var userUseCases = Context.RoleUseCase
                                      .Where(x => x.RoleId == data.RoleId)
                                      .ToList();

            Context.RoleUseCase.RemoveRange(userUseCases);

            Context.RoleUseCase.AddRange(data.UseCaseIds.Select(x =>
            new Domain.RoleUseCase
            {
                RoleId = data.RoleId,
                UseCaseId = x
            }));

            Context.SaveChanges();
        }
    }
}
