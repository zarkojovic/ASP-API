using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.Application.DTO.Roles;
using ProjectASP.Application.UseCases.Commands.Roles;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using ProjectASP.Implementation;

namespace ProjectASP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private UseCaseHandler _useCaseHandler;
        private AspContext _context;
        public RoleController(UseCaseHandler useCase, [FromServices]AspContext context)
        {
            _useCaseHandler = useCase;
            _context = context;
        }

        [HttpGet]
        public IActionResult Seeder()
        {
            List<string> Role = new List<string> { "Admin", "User" };
            foreach (var r in Role)
            {
                _context.Roles.Add(new Role
                {
                    Name = r
                });
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("{id}/access")]
        public IActionResult ModifyAccess(int id, [FromBody] ModifyRoleAccessDTO dto, [FromServices] IModifyRoleAccessCommand cmd)
        {
            dto.RoleId = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return NoContent();
        }
    }
}
