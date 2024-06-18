using FluentValidation;
using ProjectASP.Application.DTO.Categories;
using ProjectASP.Application.DTO.Package;
using ProjectASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.Validations.Packages
{
    public class CreatePackageValidator : AbstractValidator<CreatePackageDTO>
    {
        public CreatePackageValidator(AspContext context)
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Package name is required.")
                .Must(x=> !context.Packages.Any(p => p.Name == x))
                .WithMessage("Package name is already taken.")
                .MaximumLength(30)
                .WithMessage("Package name can have a maximum of 30 characters.");

            RuleFor(x => x.PageIds)
                .Must(pageIds => context.Pages.Any(s => pageIds.Contains(s.Id)))
                .When(x => x.PageIds != null)
                .WithMessage("Package can't have pages that don't exist.");
        }
    }
}
