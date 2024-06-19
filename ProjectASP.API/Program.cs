using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProjectASP.API;
using ProjectASP.API.Core;
using ProjectASP.Application;
using ProjectASP.Application.UseCases.Commands.Users;
using ProjectASP.DataAccess;
using ProjectASP.Implementation;
using ProjectASP.Implementation.Logging.UseCases;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = new AppSettings();

// Bind the data from appsettings.json in the AppSettings class
builder.Configuration.Bind(settings);

// Add Singleton for JWT configuration
builder.Services.AddSingleton(settings.Jwt);

//builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Using the HttpContextAccessor to get the Authorization header from the request
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection Configuration
builder.Services.AddTransient<AspContext>();
builder.Services.AddTransient<UseCaseHandler>();
builder.Services.AddTransient<JwtTokenCreator>();
builder.Services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();
builder.Services.AddTransient<IExceptionLogger, DbExceptionLogger>();
builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();

// Registering All Use Cases Dependencies from Extention Method
builder.Services.AddUseCases();

// Store Token Strategy 


// Retrieving the Authenticated user from JWT token
builder.Services.AddTransient<IApplicationActorProvider>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var request = accessor.HttpContext.Request;

    var authHeader = request.Headers.Authorization.ToString();

    var context = x.GetService<AspContext>();

    return new JwtApplicationActorProvider(authHeader);
});
// Trying to access Actor from the HttpContext if it exists, if not, return UnauthorizedActor
builder.Services.AddTransient<IApplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    if (accessor.HttpContext == null)
    {
        return new UnauthorizedActor();
    }

    return x.GetService<IApplicationActorProvider>().GetActor();
});
// Add Authentication and Authorization
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = settings.Jwt.Issuer,
        ValidateIssuer = true,
        ValidAudience = "Any",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
    cfg.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            //Token dohvatamo iz Authorization header-a
            Guid tokenId = context.HttpContext.Request.GetTokenId().Value;

            var storage = builder.Services.BuildServiceProvider().GetService<ITokenStorage>();

            if (!storage.Exists(tokenId))
            {
                context.Fail("Invalid token");
            }
            return Task.CompletedTask;

        }
    };
});

var app = builder.Build();
// Registering Global Exception Handling Middleware
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Registering usage of static files in the wwwroot folder
app.UseStaticFiles();

app.Run();
