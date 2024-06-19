using FluentValidation;
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
    public class EfDeleteDealCommand : EfUseCase, IDeleteDealCommand
    {
        private readonly AspContext _context;
        private readonly DeleteDealValidator _validator;
        public EfDeleteDealCommand(AspContext context, DeleteDealValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 21;

        public string Name => "DeleteDealCommand";

        public void Execute(int data)
        {
            _validator.ValidateAndThrow(data);

            var deal = _context.Deals.Find(data);

            if (deal != null)
            {
                   _context.Deals.Remove(deal);
                _context.SaveChanges();
            }

        }
    }
}
