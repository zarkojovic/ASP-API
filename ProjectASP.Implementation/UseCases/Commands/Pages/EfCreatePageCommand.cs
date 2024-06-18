using Azure;
using FluentValidation;
using ProjectASP.Application.DTO.Package;
using ProjectASP.Application.DTO.Pages;
using ProjectASP.Application.UseCases.Commands.Pages;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using ProjectASP.Implementation.Validations.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Pages
{
    public class EfCreatePageCommand : EfUseCase, ICreatePageCommand
    {
        private readonly AspContext _context;
        private readonly CreatePageValidator _validator;
        public EfCreatePageCommand(AspContext context, CreatePageValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "CreatePageCommand";

        public void Execute(CreatePageDTO data)
        {
            _validator.ValidateAndThrow(data);

            Page newPage = new Page()
            {
                Route = data.Route,
                Name = data.Name,
                Icon = data.Icon,
                RoleId = data.RoleId
            };

            if(data.PackageIds != null)
            {
                newPage.Packages = _context.Packages.Where(x => data.PackageIds.Contains(x.Id)).ToList();
            }

            _context.Pages.Add(newPage);
            _context.SaveChanges();
        }
    }
}
