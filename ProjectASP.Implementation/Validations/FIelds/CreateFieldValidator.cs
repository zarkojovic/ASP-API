using FluentValidation;
using ProjectASP.Application.DTO.Fields;
using ProjectASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.Validations.FIelds
{
    public class CreateFieldValidator : AbstractValidator<CreateFieldDTO>
    {
        public CreateFieldValidator(AspContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Key)
                .NotEmpty()
                .WithMessage("Field key is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Key)
                        .Must((dto, key) => !context.Fields.Any(f => f.Name == key))
                        .WithMessage(dto => $"Field with key {dto.Key} already exists.");
                });

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Field name is required.")
                .MinimumLength(3)
                .WithMessage("Field name must have a minimum of 3 characters.");

            List<string> allowedType = new List<string> { "text", "number", "date" , "enumeration","file"};

            RuleFor(x => x.Type)
                .Must(type => allowedType.Contains(type))
                .WithMessage("Field type is not allowed.");

            RuleFor(x => x.CategoryId)
                .Must(x => context.Categories.Any(c => c.Id == x))
                .When(x => x.CategoryId != null)
                .WithMessage("Category does not exist.");

        }
    }
}
