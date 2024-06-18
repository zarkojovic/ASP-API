using ProjectASP.Application.DTO;
using ProjectASP.Application.DTO.Fields;
using ProjectASP.Application.UseCases.Queries.Fields;
using ProjectASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Queries.Fields
{
    public class EfGetFieldsQuery : EfUseCase, IGetFieldsQuery
    {
        private readonly AspContext _context;
        public EfGetFieldsQuery(AspContext context) : base(context)
        {
            _context = context;
        }

        public int Id => 17;

        public string Name => "GetFieldsQuery";

        public PagedResponse<GetFieldsDTO> Execute(SearchFieldsDTO search)
        {
            var query = _context.Fields.AsQueryable();

            if(!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.FieldKey.ToLower().Contains(search.Name.ToLower()));
            }

            if(!string.IsNullOrEmpty(search.Type))
            {
                query = query.Where(x => x.Type.ToLower().Contains(search.Type.ToLower()));
            }

            if(search.CategoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == search.CategoryId);
            }

            if(search.IsReadOnly.HasValue)
            {
                query = query.Where(x => x.IsReadOnly == search.IsReadOnly);
            }

            if(search.IsRequired.HasValue)
            {
                query = query.Where(x => x.IsRequired == search.IsRequired);
            }
            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);


            return new PagedResponse<GetFieldsDTO>
            {
                Data = query.Select(x => new GetFieldsDTO
                {
                    Name = x.Name,
                    Key = x.FieldKey,
                    Type = x.Type,
                    ReadOnly = x.IsReadOnly,
                    Required = x.IsRequired,
                    CategoryId = x.CategoryId
                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCount,
                CurrentPage = page,
            };


        }
    }
}
