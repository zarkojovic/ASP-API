using FluentValidation;
using ProjectASP.Application.DTO.Categories;
using ProjectASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.Validations.Categories
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryValidator(AspContext context)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .Must(x => context.Categories.Any(c => c.Id == x))
                .WithMessage("Category with that id doesn't exist in database!");

            RuleFor(x => x.Name)
                .Must((dto,x) => !context.Categories.Any(c => c.Name == x && c.Id != dto.Id))
                .When(x => x.Name != null)
                .WithMessage("That name already exists in database!");

            RuleFor(x => x.StageIds)
                .Must(x => x.Distinct().Count() == x.Count())
                .When(x => x.StageIds != null)
                .WithMessage("Category cannot have duplicate stages!")
                .Must(x => context.Stages.Any(c => x.Contains(c.Id)))
                .When(x => x.StageIds != null)
                .WithMessage("Category must have stages that exist in database!");

            RuleFor(x => x.FieldIds)
                .Must(x => x.Distinct().Count() == x.Count())
                .When(x => x.FieldIds != null)
                .WithMessage("Category cannot have duplicate fields!")
                .Must(x => context.Fields.Any(c => x.Contains(c.Id)))
                .When(x => x.FieldIds != null)
                .WithMessage("Category must have fields that exist in database!");

            RuleFor(x => x.FieldIds)
                .Must(x => x.Count() == x.Distinct().Count())
                .When(x => x.FieldIds != null)
                .WithMessage("Category cannot have duplicate fields!");
            
        }
    }
}
