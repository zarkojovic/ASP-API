using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.Application;
using ProjectASP.Application.DTO.Users;
using ProjectASP.Application.UseCases.Commands.Users;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using ProjectASP.Implementation;

namespace ProjectASP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private UseCaseHandler _useCaseHandler;
        private IApplicationActorProvider _actor;
        public UserController(IApplicationActorProvider actor, UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
            _actor = actor;
        }

        [HttpGet]
        public IActionResult Index([FromServices]AspContext ctx)
        {

            return Ok(new
            {
                message = "This is the user controller."
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] RegisterUserDTO dto, [FromServices] IRegisterUserCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return Created();
        }
        [Authorize]
        [HttpPost("info")]
        public IActionResult UserInfo([FromBody]UserInfoDTO dto, [FromServices] IUserInfoCommand cmd)
        {
            dto.UserId = _actor.GetActor().Id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return Ok();
        }
    }
}
