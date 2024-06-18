using ProjectASP.Application.DTO.Fields;
using ProjectASP.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectASP.Application.DTO.Users;

namespace ProjectASP.Application.UseCases.Queries.Users
{
    public interface ISearchUsersQuery : IQuery<PagedResponse<GetUsersDTO>, SearchUsersDTO>
    {
    }
}
