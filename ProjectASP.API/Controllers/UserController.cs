using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.Application;
using ProjectASP.Application.DTO.Fields;
using ProjectASP.Application.DTO.Users;
using ProjectASP.Application.UseCases.Commands.Users;
using ProjectASP.Application.UseCases.Queries.Fields;
using ProjectASP.Application.UseCases.Queries.Users;
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
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchUsersDTO search, [FromServices] ISearchUsersQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, search));
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IFindUserQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, id));
        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] RegisterUserDTO dto, [FromServices] IRegisterUserCommand cmd)
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
        [Authorize]
        [HttpPut]
        public IActionResult Update([FromBody] UpdateUserDTO dto, [FromServices] IUpdateUserCommand cmd)
        {
            dto.Id = _actor.GetActor().Id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

    }
}
