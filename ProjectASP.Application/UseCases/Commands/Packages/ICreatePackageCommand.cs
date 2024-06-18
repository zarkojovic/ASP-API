using ProjectASP.Application.DTO.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectASP.Application.UseCases.Commands.Packages
{
    public interface ICreatePackageCommand : ICommand<CreatePackageDTO>
    {
    }
}
