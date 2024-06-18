using FluentValidation;
using ProjectASP.Application.DTO;
using ProjectASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.Validations
{
    public class LookupEntityValidator : AbstractValidator<LookupEntityDTO>
    {
        public LookupEntityValidator(AspContext context)
        {
            RuleFor(x => x.Name).
                NotNull().
                WithErrorCode("Name can't be null").
                MaximumLength(50).
                WithErrorCode("Name can't be longer than 50 characters");
                

        }
    }
}
