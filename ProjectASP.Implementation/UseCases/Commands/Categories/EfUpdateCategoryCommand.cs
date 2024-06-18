using FluentValidation;
using ProjectASP.Application.DTO.Categories;
using ProjectASP.Application.UseCases.Commands.Categories;
using ProjectASP.DataAccess;
using ProjectASP.Implementation.Validations.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Categories
{
    public class EfUpdateCategoryCommand : EfUseCase, IUpdateCategoryCommand
    {
        private readonly AspContext _context;
        private readonly UpdateCategoryValidator _validator;
        public EfUpdateCategoryCommand(AspContext context, UpdateCategoryValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 10;

        public string Name => "UpdateCategoryCommand";

        public void Execute(UpdateCategoryDTO data)
        {
            _validator.ValidateAndThrow(data);

            var category = _context.Categories.Find(data.Id);

            if(data.Name != null)
            {
                category.Name = data.Name;
            }

            if(data.StageIds != null)
            {
                category.Stages.Clear();
                category.Stages = _context.Stages.Where(x => data.StageIds.Contains(x.Id)).ToList();
            }

            if(data.FieldIds != null)
            {
                category.Fields.Clear();
                category.Fields = _context.Fields.Where(x => data.FieldIds.Contains(x.Id)).ToList();
            }

            if(data.PageIds != null)
            {
                category.Pages.Clear();
                category.Pages = _context.Pages.Where(x => data.PageIds.Contains(x.Id)).ToList();
            }

            _context.Categories.Update(category);

            _context.SaveChanges();
        }
    }
}
