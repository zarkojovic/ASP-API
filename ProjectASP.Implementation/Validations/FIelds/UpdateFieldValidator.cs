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
    public class UpdateFieldValidator : AbstractValidator<UpdateFieldDTO>
    {
        public UpdateFieldValidator(AspContext context)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Field Id is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .Must(id => context.Fields.Any(x => x.Id == id))
                        .WithMessage("Field with an id of {PropertyValue} does not exist.");
                });

            RuleFor(x => x.CategoryId)
                .Must(id => context.Categories.Any(x => x.Id == id))
                .When(x => x.CategoryId != null)
                .WithMessage("Category with an id of {PropertyValue} does not exist.");

            List<string> allowedType = new List<string> { "text", "number", "date", "enumeration", "file" };

            RuleFor(x => x.Type)
                .Must(type => allowedType.Contains(type))
                .When(x => x.Type != null)
                .WithMessage("Field type is not allowed.");

            RuleFor(x => x.Key)
                .Must((dto, key) => !context.Fields.Any(f => f.Name == key && f.Id != dto.Id))
                .When(x => x.Key != null)
                .WithMessage(dto => $"Field with key {dto.Key} already exists.");

            RuleFor(x => x.Name)
                .MinimumLength(3)
                .When(x => x.Name != null)
                .WithMessage("Field name must have a minimum of 3 characters.");


        }
    }
}
