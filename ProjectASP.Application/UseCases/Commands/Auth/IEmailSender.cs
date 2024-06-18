using ProjectASP.Application.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.UseCases.Commands.Auth
{
    public interface IEmailServiceProvider
    {
        public Task SendEmail(SendEmailDTO dto);
    }
}
