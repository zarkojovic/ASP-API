using ProjectASP.Application.DTO.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.UseCases.Commands.Deals
{
    public interface IUpdateDealCommand : ICommand<IUpdateDealDTO>
    {
    }
}