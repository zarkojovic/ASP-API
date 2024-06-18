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
    public class GetQueryValidator : AbstractValidator<GetFieldsDTO>
    {
        public GetQueryValidator(AspContext context)
        {
            
        }
    }
}
