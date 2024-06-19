using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.Application.DTO;
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
        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] LookupEntityDTO dto, [FromServices] ICreateRoleCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return Created();
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] LookupEntityDTO dto)
        {

            Role role = _context.Roles.Find(id);

            if (role == null)
            {
                throw new NullReferenceException("Role not found.");
            }

            role.Name = dto.Name;

            _context.SaveChanges();

            return Ok();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {

            Role role = _context.Roles.Find(id);

            if (role == null)
            {
                throw new NullReferenceException("Role not found.");
            }

            if(role.Users.Count > 0)
            {
                throw new Exception("Role has users.");
            }

            _context.Roles.Remove(role);

            _context.SaveChanges();

            return Ok();
        }



    }
}
