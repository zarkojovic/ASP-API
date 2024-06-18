using FluentValidation;
using ProjectASP.Application.DTO.Package;
using ProjectASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.Validations.Packages
{
    public class UpdatePackageValidator : AbstractValidator<UpdatePackageDTO>
    {
        public UpdatePackageValidator(AspContext context)
        {
            RuleFor(x => x.Id)
                .Must(id => context.Packages.Any(p => p.Id == id))
                .WithMessage("Package with an id of {PropertyValue} does not exist.");
        
            RuleFor(x => x.Name)
                .Must((dto,x) => !context.Packages.Any(p => p.Name == x && p.Id == dto.Id))
                .When(x => x.Name != null)
                .WithMessage("Package with a name of {PropertyValue} already exists.");



            RuleFor(x => x.PageIds)
                .Must(ids => ids.All(id => context.Pages.Any(p => p.Id == id)))
                .When(x => x.PageIds != null)
                .WithMessage("Some of the provided page ids do not exist.");
                
        }
    }
}
