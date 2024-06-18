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
    public class UpdatePageValidator : AbstractValidator<UpdatePageDTO>
    {
        public UpdatePageValidator(AspContext context)
        {
            RuleFor(x => x.Id)
                               .NotEmpty()
                .WithMessage("Id is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .Must(id => context.Pages.Any(x => x.Id == id))
                        .WithMessage("Page with an id of {PropertyValue} doesn't exist.");
                });

            RuleFor(x => x.Name)
                .MinimumLength(3)
                .When(x => x.Name != null)
                .WithMessage("Name must have a minimum of 3 characters.");

            RuleFor(x => x.Route)
                .Must((dto, x) => !context.Pages.Any(p => p.Name == x && p.Id == dto.Id))
                .When(x => x.Name != null)
                .WithMessage("Page with a name of {PropertyValue} already exists.");

            RuleFor(x => x.RoleId)
                .Must(x => context.Roles.Any(r => r.Id == x))
                .When(x => x.RoleId != null)
                .WithMessage("Role with an id of {PropertyValue} doesn't exist.");

            RuleFor(x => x.Icon)
                .MinimumLength(3)
                .When(x => x.Icon != null)
                .WithMessage("Icon must have a minimum of 3 characters.");

            RuleFor(x => x.PackageIds)
                .Must(ids => ids.All(id => context.Packages.Any(p => p.Id == id)))
                .When(x => x.PackageIds != null)
                .WithMessage("Package with an id of {PropertyValue} doesn't exist.");
        }
    }
}
