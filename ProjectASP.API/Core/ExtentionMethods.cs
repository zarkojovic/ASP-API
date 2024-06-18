using FluentValidation;
using ProjectASP.Application.DTO;
using ProjectASP.Application.UseCases.Commands.Auth;
using ProjectASP.Application.UseCases.Commands.Categories;
using ProjectASP.Application.UseCases.Commands.Deals;
using ProjectASP.Application.UseCases.Commands.Fields;
using ProjectASP.Application.UseCases.Commands.Packages;
using ProjectASP.Application.UseCases.Commands.Pages;
using ProjectASP.Application.UseCases.Commands.Roles;
using ProjectASP.Application.UseCases.Commands.Users;
using ProjectASP.Application.UseCases.Queries.Categories;
using ProjectASP.Application.UseCases.Queries.Fields;
using ProjectASP.Application.UseCases.Queries.Users;
using ProjectASP.Implementation.UseCases.Commands.Auth;
using ProjectASP.Implementation.UseCases.Commands.Categories;
using ProjectASP.Implementation.UseCases.Commands.Deals;
using ProjectASP.Implementation.UseCases.Commands.Fields;
using ProjectASP.Implementation.UseCases.Commands.Packages;
using ProjectASP.Implementation.UseCases.Commands.Pages;
using ProjectASP.Implementation.UseCases.Commands.Roles;
using ProjectASP.Implementation.UseCases.Commands.Users;
using ProjectASP.Implementation.UseCases.Queries.Categories;
using ProjectASP.Implementation.UseCases.Queries.Fields;
using ProjectASP.Implementation.UseCases.Queries.Users;
using ProjectASP.Implementation.Validations;
using ProjectASP.Implementation.Validations.Categories;
using ProjectASP.Implementation.Validations.Deals;
using ProjectASP.Implementation.Validations.FIelds;
using ProjectASP.Implementation.Validations.Packages;
using ProjectASP.Implementation.Validations.Pages;
using ProjectASP.Implementation.Validations.Roles;
using ProjectASP.Implementation.Validations.Users;
using System.IdentityModel.Tokens.Jwt;

namespace ProjectASP.API.Core
{
    public static class ExtentionMethods
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<RegisterUserDtoValidator>();
            services.AddTransient<IModifyRoleAccessCommand, EfModifyRoleAccessCommand>();
            services.AddTransient<ModifyRoleAccessValidator>();
            services.AddTransient<IUserInfoCommand, EfUserInfoCommand>();
            services.AddTransient<UserInfoDtoValidator>();
            services.AddTransient<ICreateDealCommand, EfCreateDealCommand>();
            services.AddTransient<CreateDealValidator>();
            services.AddTransient<IEmailServiceProvider, SmtpEmailSender>();
            services.AddTransient<IUpdateDealCommand, EfUpdateDealCommand>();
            services.AddTransient<UpdateDealValidator>();
            services.AddTransient<ICreateRoleCommand, EfCreateRoleCommand>();
            services.AddTransient<LookupEntityValidator>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<ICreatePackageCommand, EfCreatePackageCommand>();
            services.AddTransient<CreatePackageValidator>();
            services.AddTransient<IUpdatePackageCommand, EfUpdatePackageCommand>();
            services.AddTransient<UpdatePackageValidator>();
            services.AddTransient<ICreatePageCommand, EfCreatePageCommand>();
            services.AddTransient<CreatePageValidator>();
            services.AddTransient<IUpdatePageCommand, EfUpdatePageCommand>();
            services.AddTransient<UpdatePageValidator>();
            services.AddTransient<ICreateFieldCommand, EfCreateFieldCommand>();
            services.AddTransient<CreateFieldValidator>();
            services.AddTransient<IUpdateFieldCommand, EfUpdateFieldCommand>();
            services.AddTransient<UpdateFieldValidator>();
            services.AddTransient<IGetFieldsQuery, EfGetFieldsQuery>();
            services.AddTransient<ISearchUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IFindUserQuery, EfFindUserQuery>();
            services.AddTransient<IFindCategoryQuery, EfFindCategoryQuery>();
        }
        public static Guid? GetTokenId(this HttpRequest request)
        {
            if (request == null || !request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = request.Headers["Authorization"].ToString();

            if (authHeader.Split("Bearer ").Length != 2)
            {
                return null;
            }

            string token = authHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var tokenGuid = Guid.Parse(claim);

            return tokenGuid;
        }

    }
}
