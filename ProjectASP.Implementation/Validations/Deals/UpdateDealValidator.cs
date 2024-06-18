using FluentValidation;
using ProjectASP.Application.DTO.Deals;
using ProjectASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.Validations.Deals
{
    public class UpdateDealValidator : AbstractValidator<IUpdateDealDTO>
    {
        
        public UpdateDealValidator(AspContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.DealId)
                .Must((dto, dealId) => context.Deals.Any(d => d.Id == dealId))
                .WithMessage("Deal with that id doesn't exist in database.");

            RuleFor(x => x.StageId)
                .Must((dto, stageId) => context.Stages.Any(s => s.Id == stageId))
                .When(x => x.StageId != null )
                .WithMessage("Stage with that id doesn't exist in database.");

        }
    }
}
