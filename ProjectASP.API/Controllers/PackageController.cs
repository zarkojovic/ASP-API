using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.Application.DTO.Package;
using ProjectASP.Application.UseCases.Commands.Packages;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using ProjectASP.Implementation;

namespace ProjectASP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : Controller
    {
        private readonly AspContext _context;
        private readonly UseCaseHandler _useCaseHandler;
        public PackageController([FromServices]AspContext context, [FromServices]UseCaseHandler useCaseHandler) 
        { 
            _context = context;
            _useCaseHandler = useCaseHandler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                List<Package> packages = _context.FieldItems
                    .Where(x => x.Field.FieldKey == "Package")
                    .Select(x => new Package
                    {
                        Name = x.Name,
                        Pages = _context.Pages.ToList()
                    })
                    .ToList();

                _context.Packages.AddRange(packages);

                _context.SaveChanges();

                return Ok(packages);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromServices] ICreatePackageCommand cmd, [FromBody] CreatePackageDTO dto)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromServices] IUpdatePackageCommand cmd, [FromBody] UpdatePackageDTO dto)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {

            Package package = _context.Packages.Find(id);

            if (package == null)
            {
                throw new NullReferenceException("Package not found.");
            }

            if (package.Users.Count > 0)
            {
                throw new Exception("Package has users.");
            }

            _context.Packages.Remove(package);

            _context.SaveChanges();

            return Ok();
        }
    }
}
