using FluentValidation;
using ProjectASP.Application.DTO.Package;
using ProjectASP.Application.UseCases.Commands.Packages;
using ProjectASP.DataAccess;
using ProjectASP.Implementation.Validations.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Packages
{
    public class EfUpdatePackageCommand : EfUseCase, IUpdatePackageCommand
    {
        private readonly AspContext _context;
        private readonly UpdatePackageValidator _validator;
        public EfUpdatePackageCommand(AspContext context, UpdatePackageValidator validator) : base(context)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 12;

        public string Name => "UpdatePackageCommand";

        public void Execute(UpdatePackageDTO data)
        {
            _validator.ValidateAndThrow(data);

            var package = _context.Packages.Find(data.Id);

            if(data.Name != null)
            {
                package.Name = data.Name;
            }

            if(data.PageIds != null)
            {
                package.Pages.Clear();
                package.Pages = _context.Pages.Where(x => data.PageIds.Contains(x.Id)).ToList();
            }

            _context.Packages.Update(package);
            
            _context.SaveChanges();
        }
    }
}
