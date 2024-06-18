using FluentValidation;
using ProjectASP.Application.DTO.Users;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.Validations.Users
{
    public class UserInfoDtoValidator : AbstractValidator<UserInfoDTO>
    {
        public readonly AspContext _context;
        public UserInfoDtoValidator(AspContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            _context = context;

            RuleFor(x => x.UserId)
                .NotNull()
                .WithMessage("UserId is required.")
                .Must(x => _context.Users.Any(u => u.Id == x))
                .WithMessage("UserId does not exist in database.");

            RuleFor(x => x.FieldId)
                .NotNull()
                .WithMessage("FieldId is required.")
                .Must(x => _context.Fields.Any(f => f.Id == x))
                .WithMessage("FieldId does not exist in database.")
                .Must(x => _context.Fields.Any(f => f.Id == x && f.CategoryId != null))
                .WithMessage("FieldId doesn't belong to any category.")
                .Must(x => _context.Fields.Any(f => f.Id == x && !f.IsReadOnly))
                .WithMessage("You can't change read only fields.")
                .DependentRules(() =>
                {

                    RuleFor(x => x.Value)
                        .Must((dto, x) =>
                        {
                            Field field = _context.Fields.Find(dto.FieldId);
                            //List<string> bannedTypes = new List<string> { "string", "datetime", "crm" , "url", "bool", "date", "enumeration" };
                            List<string> bannedTypes = new List<string> { "file" };

                            if (!bannedTypes.Contains(field.Type))
                            {
                                if (x == null || x.Length == 0)
                                {
                                    return false;
                                }
                            }
                            return true;
                        })
                        .WithMessage("Value is required for this field type.");

                    RuleFor(x => x.DisplayValue)
                        .Must((dto, x) =>
                        {
                            Field field = _context.Fields.Find(dto.FieldId);
                            List<string> allowedTypes = new List<string> { "enumeration" };
                            if (allowedTypes.Contains(field.Type))
                            {
                                if (x == null || x.Length == 0)
                                {
                                    return false;
                                }
                            }
                            return true;

                        }).WithMessage("DisplayValue is required for this field type.");

                    RuleFor(x => x.FilePath)
                        .Must((dto, x) =>
                        {
                            Field field = _context.Fields.Find(dto.FieldId);
                            List<string> allowedTypes = new List<string> { "file" };

                            if (allowedTypes.Contains(field.Type))
                            {
                                if (x == null || x.Length == 0)
                                {
                                    return false;
                                }
                            }
                            return true;
                        }).WithMessage("FilePath is required for this field type."); ;

                    RuleFor(x => x.FileName)
                        .Must((dto, x) =>
                        {
                            Field field = _context.Fields.Find(dto.FieldId);
                            List<string> allowedTypes = new List<string> { "file" };

                            if (allowedTypes.Contains(field.Type))
                            {
                                if (x == null || x.Length == 0)
                                {
                                    return false;
                                }
                            }
                            return true;
                        }).WithMessage("FileName is required for this field type."); ;

                });

        }
    }
}
