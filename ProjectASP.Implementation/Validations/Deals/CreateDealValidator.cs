using FluentValidation;
using ProjectASP.Application.DTO.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.Validations.Deals
{
    public class CreateDealValidator : AbstractValidator<ICreateDealDTO>
    {
        public CreateDealValidator()
        {
            RuleFor(x => x.Degree)
                .NotNull()
                .WithMessage("Degree can't be empty!");

            RuleFor(x => x.Program)
                .NotNull()
                .WithMessage("Program can't be empty!");

            RuleFor(x => x.University)
                .NotNull()
                .WithMessage("University can't be empty!");



        }
    }
}
