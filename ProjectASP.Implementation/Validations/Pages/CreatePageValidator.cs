using FluentValidation;
using ProjectASP.Application.DTO.Pages;
using ProjectASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.Validations.Pages
{
    public class CreatePageValidator : AbstractValidator<CreatePageDTO>
    {
        public CreatePageValidator(AspContext context)
        {
            RuleFor(x => x.Route)
                .NotEmpty().WithMessage("Route is required.").DependentRules(() =>
                {
                RuleFor(x => x.Route).Must(route => !context.Pages.Any(p => p.Route == route)).WithMessage("Route must be unique.");
            });

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Icon is required.");

            RuleFor(x => x.PackageIds)
                .Must(x => x.All(id => context.Packages.Any(p => p.Id == id)))
                .When(x => x.PackageIds != null && x.PackageIds.Count > 0)
                .WithMessage("Package id does not exist.");

            RuleFor(x => x.RoleId)
                .Must(id => context.Roles.Any(r => r.Id == id))
                .WithMessage("Role id does not exist.");
        }
    }
}
