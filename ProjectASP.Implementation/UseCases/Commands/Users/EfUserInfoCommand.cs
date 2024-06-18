using FluentValidation;
using ProjectASP.Application.DTO.Users;
using ProjectASP.Application.UseCases.Commands.Users;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using ProjectASP.Implementation.Validations.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Commands.Users
{
    public class EfUserInfoCommand : IUserInfoCommand
    {
        public int Id => 4;

        public string Name => "NewUserInfo";

        private readonly AspContext _context;
        private UserInfoDtoValidator _validator;
        public EfUserInfoCommand(AspContext context, UserInfoDtoValidator validator)
        {
            _validator = validator;
            _context = context;
        }
        public void Execute(UserInfoDTO data)
        {
            
            this._validator.ValidateAndThrow(data);

            Field field = _context.Fields.Find(data.FieldId);
            
            UserInfo userInfo;
            UserInfo doesExist = _context.UserInfo.FirstOrDefault(x => x.UserId == data.UserId && x.FieldId == data.FieldId);

            if(doesExist != null)
            {
                userInfo = doesExist;
            }
            else
            {
                userInfo = new UserInfo();
            }

            if (field.Type == "file")
            {
                userInfo.UserId = data.UserId;
                userInfo.FieldId = data.FieldId;
                userInfo.FileName = data.FileName;
                userInfo.FilePath = data.FilePath;
                
            }
            else if(field.Type == "enumeration")
            {

                userInfo.UserId = data.UserId;
                userInfo.FieldId = data.FieldId;
                userInfo.Value = data.Value;
                userInfo.DisplayValue = data.DisplayValue;
            }
            else
            {
                userInfo.UserId = data.UserId;
                userInfo.FieldId = data.FieldId;
                userInfo.Value = data.Value;
            }

            if(doesExist == null)
            {
                _context.UserInfo.Add(userInfo);
            }

            _context.SaveChanges();

        }
    }
}
