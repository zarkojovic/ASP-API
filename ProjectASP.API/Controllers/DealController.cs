using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.Application;
using ProjectASP.Application.DTO.Deals;
using ProjectASP.Application.DTO.Users;
using ProjectASP.Application.UseCases.Commands.Deals;
using ProjectASP.Application.UseCases.Commands.Users;
using ProjectASP.Implementation;
using System.Numerics;

namespace ProjectASP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DealController : Controller
    {
        private UseCaseHandler _useCaseHandler;
        public DealController(IApplicationActorProvider actor, UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] ICreateDealDTO dto, [FromServices] ICreateDealCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return Ok();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id, [FromServices] IDeleteDealCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, id);
            return Ok();
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]IUpdateDealDTO dto, [FromServices] IUpdateDealCommand cmd)
        {
            dto.DealId = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return Ok();
        }
 }
}
