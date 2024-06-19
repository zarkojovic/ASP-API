using FluentValidation;
using ProjectASP.Application;
using ProjectASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.Validations.Deals
{
    public class DeleteDealValidator : AbstractValidator<int>
    {
        public DeleteDealValidator(IApplicationActorProvider actorProvider, AspContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            IApplicationActor actor = actorProvider.GetActor();
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("Id was not provided!")
                .Must(x => context.Deals.Any(d => d.Id == x && d.UserId == actor.Id ))
                .WithMessage("You can't modify this deal!")
                .Must(x => context.Deals.Any(d => d.Id == x && d.Stage.Name == "New Application"))
                .WithMessage("You can't delete deal past 'New Application' stage!");
        }
    }
}
