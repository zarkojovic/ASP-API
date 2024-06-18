using ProjectASP.Application.DTO.Users;
using ProjectASP.Application.UseCases.Queries.Users;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.UseCases.Queries.Users
{
    public class EfFindUserQuery : EfUseCase, IFindUserQuery
    {
        private readonly AspContext _context;
        public EfFindUserQuery(AspContext context) : base(context)
        {
            _context = context;
        }

        public int Id => 19;

        public string Name => "FindUserQuery";

        public UserDetailDTO Execute(int search)
        {

            User user = _context.Users.Find(search);


            if (user == null)
            {
                throw new Exception("User not found.");
            }

            return new UserDetailDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                PackageId = user.PackageId,
                PackageName = user.Package.Name,
                RoleId = user.RoleId,
                RoleName = user.Role.Name,
                UserDeals = user.Deals.Select(x => new Application.DTO.Deals.GetDealsDTO
                {
                    University = x.University,
                    Degree = x.Degree,
                    Program = x.Program,
                    StageId = x.StageId,
                    StageName = x.Stage.Name,
                }).ToList(),
                UserInfo = user.UserInfo.Select(x => new GetUserInfoDTO
                {
                    FieldId = x.FieldId,
                    FieldName = x.Field.Name,
                    Value = x.Value,
                    DisplayValue = x.DisplayValue,
                    FileName = x.FileName,
                    FilePath = x.FilePath,
                }).ToList(),

            };

        }
    }
}
