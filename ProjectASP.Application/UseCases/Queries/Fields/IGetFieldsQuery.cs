using ProjectASP.Application.DTO;
using ProjectASP.Application.DTO.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.UseCases.Queries.Fields
{
    public interface IGetFieldsQuery : IQuery<PagedResponse<GetFieldsDTO>, SearchFieldsDTO>
    {
    }
}
