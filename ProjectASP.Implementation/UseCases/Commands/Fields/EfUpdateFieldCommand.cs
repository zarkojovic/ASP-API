using FluentValidation;
using ProjectASP.Application.DTO.Fields;
using ProjectASP.Application.UseCases.Commands.Fields;
using ProjectASP.DataAccess;
using ProjectASP.Implementation.Validations.FIelds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Fields
{
    public class EfUpdateFieldCommand : EfUseCase, IUpdateFieldCommand
    {   
        private readonly AspContext _context;
        private readonly UpdateFieldValidator _validator;
        public EfUpdateFieldCommand(AspContext context, UpdateFieldValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 16;

        public string Name => "UpdateFieldCommand";

        public void Execute(UpdateFieldDTO data)
        {

            _validator.ValidateAndThrow(data);

            var field = _context.Fields.Find(data.Id);

            if(data.Name != null)
            {
                field.FieldKey = data.Name;
            }

            if(data.Key != null)
            {
                field.Name = data.Key;
            }

            if(data.Type != null)
            {
                field.Type = data.Type;
            }

            if(data.CategoryId != null)
            {
                field.CategoryId = data.CategoryId.Value;
            }

            if(data.ReadOnly != null)
            {
                field.IsReadOnly = data.ReadOnly.Value;
            }

            if(data.Required != null)
            {
                field.IsRequired = data.Required.Value;
            }
            if(data.CategoryId != null)
            {
                field.CategoryId = data.CategoryId.Value;
            }

            _context.Fields.Update(field); 

            _context.SaveChanges();

        }
    }
}
