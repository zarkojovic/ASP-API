using FluentValidation;
using ProjectASP.Application.DTO.Pages;
using ProjectASP.Application.UseCases.Commands.Pages;
using ProjectASP.DataAccess;
using ProjectASP.Implementation.Validations.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Pages
{
    public class EfUpdatePageCommand : EfUseCase, IUpdatePageCommand
    {
        private readonly AspContext _context;
        private readonly UpdatePageValidator _validator;
        public EfUpdatePageCommand(AspContext context, UpdatePageValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 14;

        public string Name => "UpdatePageCommand";

        public void Execute(UpdatePageDTO data)
        {
            _validator.ValidateAndThrow(data);

            var page = _context.Pages.Find(data.Id);

            if(data.Name != null)
            {
                page.Name = data.Name;
            }

            if(data.Route != null)
            {
                page.Route = data.Route;
            }

            if(data.Icon != null)
            {
                page.Icon = data.Icon;
            }

            if(data.RoleId != null)
            {
                page.Role = _context.Roles.Find(data.RoleId);
            }

            if(data.PackageIds != null)
            {
                page.Packages.Clear();
                page.Packages = _context.Packages.Where(x => data.PackageIds.Contains(x.Id)).ToList();
            }

            _context.Pages.Update(page);

            _context.SaveChanges();
        }
    }
}
