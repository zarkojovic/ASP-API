using FluentValidation;
using ProjectASP.Application.DTO.Categories;
using ProjectASP.Application.DTO.Package;
using ProjectASP.Application.UseCases.Commands.Categories;
using ProjectASP.Application.UseCases.Commands.Packages;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using ProjectASP.Implementation.Validations.Categories;
using ProjectASP.Implementation.Validations.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Packages
{
    public class EfCreatePackageCommand : EfUseCase, ICreatePackageCommand
    {
        private readonly AspContext _context;
        private readonly CreatePackageValidator _validator;
        public EfCreatePackageCommand(AspContext context, CreatePackageValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 11;
        public string Name => "CreatePackageCommand";
        public void Execute(CreatePackageDTO data)
        {
            _validator.ValidateAndThrow(data);

            Package newPackage = new Package()
            {
                Name = data.Name
            };

            if(data.PageIds != null)
            {
                newPackage.Pages = _context.Pages.Where(x => data.PageIds.Contains(x.Id)).ToList();
            }

            _context.Packages.Add(newPackage);
            _context.SaveChanges();
        }
    }
}
