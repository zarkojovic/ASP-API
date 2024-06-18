using ProjectASP.Application.DTO.Package;
using ProjectASP.Application.DTO.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.UseCases.Commands.Pages
{
    public interface ICreatePageCommand : ICommand<CreatePageDTO>
    {
    }
}
