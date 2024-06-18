using ProjectASP.Application.DTO.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.UseCases.Commands.Packages
{
    public interface IUpdatePackageCommand : ICommand<UpdatePackageDTO>
    {
    }
}
