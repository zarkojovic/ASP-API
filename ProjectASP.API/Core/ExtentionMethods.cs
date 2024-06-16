using ProjectASP.Application.UseCases.Commands.Roles;
using ProjectASP.Application.UseCases.Commands.Users;
using ProjectASP.Implementation.UseCases.Commands.Roles;
using ProjectASP.Implementation.UseCases.Commands.Users;
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
