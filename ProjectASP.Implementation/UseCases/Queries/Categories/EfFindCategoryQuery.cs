using ProjectASP.Application.DTO.Categories;
using ProjectASP.Application.DTO.Fields;
using ProjectASP.Application.UseCases.Queries.Categories;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Queries.Categories
{
    public class EfFindCategoryQuery : EfUseCase, IFindCategoryQuery
    {
        private readonly AspContext _context;
        public EfFindCategoryQuery(AspContext context) : base(context)
        {
            _context = context;
        }

        public int Id => 20;

        public string Name => "FindCategoryCommand";

        public FindCategoryDTO Execute(int search)
        {
            Category category = _context.Categories.Find(search);

            if (category == null)
            {
                throw new Exception("Category not found.");
            }

            return new FindCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Fields = category.Fields.Select(x => new GetFieldsDTO
                {
                    Key = x.Name,
                    Type = x.Type,
                    Name = x.FieldKey,
                    ReadOnly = x.IsReadOnly,
                    Required = x.IsRequired,
                    CategoryId = x.CategoryId
                }).ToList()
            };
        }
    }
}
