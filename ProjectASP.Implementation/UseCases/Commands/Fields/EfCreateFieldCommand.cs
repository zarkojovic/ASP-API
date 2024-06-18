using FluentValidation;
using ProjectASP.Application.DTO.Fields;
using ProjectASP.Application.UseCases.Commands.Fields;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using ProjectASP.Implementation.Validations.FIelds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Fields
{
    public class EfCreateFieldCommand : EfUseCase, ICreateFieldCommand
    {
        private readonly AspContext _context;
        private readonly CreateFieldValidator _validator;
        public EfCreateFieldCommand(AspContext context, CreateFieldValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 15;

        public string Name => "CreateFieldCommand";

        public void Execute(CreateFieldDTO data)
        {
            _validator.ValidateAndThrow(data);

            Field newFiled = new Field()
            {
                FieldKey = data.Name,
                Name = data.Key,
                Type = data.Type,
                IsRequired = data.Required,
                IsReadOnly = data.ReadOnly
            };

            if(data.CategoryId != null)
            {
                newFiled.Category = _context.Categories.Find(data.CategoryId);
            }

            _context.Fields.Add(newFiled);

            _context.SaveChanges();
        }
    }
}
