using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using ProjectASP.Application.DTO.Deals;
using ProjectASP.Application.UseCases.Commands.Deals;
using ProjectASP.DataAccess;
using ProjectASP.Implementation.Validations.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Deals
{
    public class EfUpdateDealCommand : EfUseCase, IUpdateDealCommand
    {
        private AspContext _context;
        private UpdateDealValidator _validator;
        public EfUpdateDealCommand(AspContext context, UpdateDealValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "UpdateDeal";

        public void Execute(IUpdateDealDTO data)
        {
            _validator.ValidateAndThrow(data);

            var deal = _context.Deals.Find(data.DealId);

            if (!data.Degree.IsNullOrEmpty())
            {
                deal.Degree = data.Degree;
            }

            if(!data.Program.IsNullOrEmpty())
            {
                deal.Program = data.Program;
            }

            if(!data.University.IsNullOrEmpty())
            {
                deal.University = data.University;
            }
            if(data.StageId.HasValue)
            {
                deal.StageId = data.StageId.Value;
            }

            _context.SaveChanges();

        }
    }
}
