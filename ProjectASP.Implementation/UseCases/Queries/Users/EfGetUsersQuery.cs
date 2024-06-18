using ProjectASP.Application.DTO;
using ProjectASP.Application.DTO.Fields;
using ProjectASP.Application.DTO.Users;
using ProjectASP.Application.UseCases.Queries.Users;
using ProjectASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Queries.Users
{
    public class EfGetUsersQuery : EfUseCase, ISearchUsersQuery
    {
        private readonly AspContext _context;
        public EfGetUsersQuery(AspContext context) : base(context)
        {
            _context = context;
        }

        public int Id => 18;

        public string Name => "SearchUsersQuery";

        public PagedResponse<GetUsersDTO> Execute(SearchUsersDTO search)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.Username))
            {
                query = query.Where(x => x.Username.ToLower().Contains(search.Username.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(search.Email.ToLower()));
            }

            if (search.PackageId.HasValue)
            {
                query = query.Where(x => x.PackageId == search.PackageId);
            }

            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);


            return new PagedResponse<GetUsersDTO>
            {
                Data = query.Select(x => new GetUsersDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Image = x.ProfileImage,
                    Phone = x.Phone,
                    RoleId = x.RoleId,
                    Username = x.Username
                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
                CurrentPage = page,
            };


        }
    }
}
