using ProjectASP.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.UseCases.Queries.Users
{
    public interface IFindUserQuery : IQuery<UserDetailDTO, int>
    {
    }
}
