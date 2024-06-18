using Castle.Core.Smtp;
using ProjectASP.Application.DTO.Auth;
using ProjectASP.Application.UseCases.Commands.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Auth
{
    public class SmtpEmailSender : IEmailServiceProvider
    {
        public Task SendEmail(SendEmailDTO dto)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com",587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("gamerisub@gmail.com", "leskikiixvvytuvr")
            };

            return smtp.SendMailAsync(
                new MailMessage(
                    from: "gamerisub@gmail.com",
                    to: dto.Email,
                    subject: dto.Subject,
                    body: dto.Content   
                )
            );
        }
    }
}
