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
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryValidator(AspContext context)
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Category name is required.")
                .MaximumLength(50)
                .WithMessage("Category name can't be longer than 50 characters.");

            RuleFor(x => x.StageIds)
                .Must(stageIds => stageIds.Distinct().Count() == stageIds.Count())
                .When(x => x.StageIds != null)
                .WithMessage("Category can't have duplicate stages.")
                .Must(stageIds => context.Stages.Any(s => stageIds.Contains(s.Id)))
                .When(x => x.StageIds != null)
                .WithMessage("Category can't have stages that don't exist.");

            RuleFor(x => x.PageIds)
                .Must(pageIds => pageIds.Distinct().Count() == pageIds.Count())
                .When(x => x.PageIds != null)
                .WithMessage("Category can't have duplicate pages.")
                .Must(pageIds => context.Pages.Any(p => pageIds.Contains(p.Id)))
                .When(x => x.PageIds != null)
                .WithMessage("Category can't have pages that don't exist.");

            RuleFor(x => x.FieldIds)
                .Must(fieldIds => fieldIds.Distinct().Count() == fieldIds.Count())
                .When(x => x.FieldIds != null)
                .WithMessage("Category can't have duplicate fields.")
                .Must(fieldIds => context.Fields.Any(f => fieldIds.Contains(f.Id)))
                .When(x => x.FieldIds != null)
                .WithMessage("Category can't have fields that don't exist.");

        }
    }
}
