using FluentValidation;
using ProjectASP.Application.DTO.Categories;
using ProjectASP.Application.UseCases.Commands.Categories;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using ProjectASP.Implementation.Validations.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Categories
{
    public class EfCreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    {
        private readonly AspContext _context;
        private readonly CreateCategoryValidator _validator;
        public EfCreateCategoryCommand(AspContext context, CreateCategoryValidator validator) : base(context)
        {
            _context = context; 
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "CreateCategoryCommand";

        public void Execute(CreateCategoryDTO data)
        {
            _validator.ValidateAndThrow(data);

            Category category = new Category
            {
                Name = data.Name
            };

            if(data.StageIds != null)
            {
                List<Stage> stages = _context.Stages.Where(x => data.StageIds.Contains(x.Id)).ToList();
                category.Stages = stages;
            }

            if(data.PageIds != null)
            {
                List<Page> pages = _context.Pages.Where(x => data.PageIds.Contains(x.Id)).ToList();
                category.Pages = pages;
            }

            if(data.FieldIds != null)
            {
                List<Field> fields = _context.Fields.Where(x => data.FieldIds.Contains(x.Id)).ToList();
                category.Fields = fields;
            }


            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
