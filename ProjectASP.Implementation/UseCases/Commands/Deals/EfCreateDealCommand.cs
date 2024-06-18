
using FluentValidation;
using ProjectASP.Application;
using ProjectASP.Application.DTO.Deals;
using ProjectASP.Application.UseCases.Commands.Deals;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using ProjectASP.Implementation.Validations.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Deals
{
    public class EfCreateDealCommand : EfUseCase, ICreateDealCommand
    {
        public readonly CreateDealValidator _validator;
        public readonly AspContext _context;
        public readonly IApplicationActorProvider _actor;
        public EfCreateDealCommand(AspContext context, CreateDealValidator validator,IApplicationActorProvider actor) : base(context)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 5;

        public string Name => "CreatingDeal";

        public void Execute(ICreateDealDTO data)
        {
            _validator.ValidateAndThrow(data);

            // Step 1: Retrieve the required field IDs
            var requiredFieldIds = _context.Fields
                .Where(x => x.IsRequired && x.CategoryId != null)
                .Select(x => x.Id)
                .ToList();

            // Step 2: Retrieve the user's filled field IDs
            var userFilledFieldIds = _context.UserInfo
                .Where(x => x.UserId == _actor.GetActor().Id)
                .Select(x => x.FieldId)
                .ToList();

            // Step 3: Check if the user has filled all the required fields
            var hasFilledAllFields = !requiredFieldIds.Except(userFilledFieldIds).Any();

            Deal newDeal = new()
            {
                University = data.University,
                Degree = data.Degree,
                Program = data.Program,
                Stage = _context.Stages.FirstOrDefault(x => x.Name == "New Application"),
                User = _context.Users.FirstOrDefault(x => x.Id == _actor.GetActor().Id)
            };

            _context.Deals.Add(newDeal);

            _context.SaveChanges();

        }
    }
}
