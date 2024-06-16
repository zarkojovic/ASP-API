using FluentValidation;
using ProjectASP.Application.DTO.Roles;
using ProjectASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.Validations.Roles
{
    public class ModifyRoleAccessValidator : AbstractValidator<ModifyRoleAccessDTO>
    {
        private static int updateRegisterAccessId = 3;
        public ModifyRoleAccessValidator(AspContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.RoleId)
                    .Must(x => context.Roles.Any(r => r.Id == x && r.IsActive))
                    .WithMessage("Requested role doesn't exist.")
                    .Must(x => !context.RoleUseCase.Any(r => r.UseCaseId == updateRegisterAccessId && r.RoleId == x))
                    .WithMessage("Not allowed to change this role.");

            RuleFor(x => x.UseCaseIds)
                .NotEmpty().WithMessage("Parameter is required.")
                .Must(x => x.All(id => id > 0 && id <= UseCaseInfo.MaxUseCaseId)).WithMessage("Invalid usecase id range.")
                .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Only unique usecase ids must be delivered.");


        }
    }
}
