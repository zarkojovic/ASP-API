using ProjectASP.Application.DTO.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.UseCases.Queries.Categories
{
    public interface IFindCategoryQuery : IQuery<FindCategoryDTO, int>
    {
    }
}
