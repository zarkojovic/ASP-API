using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.DataAccess;
using ProjectASP.Domain;

namespace ProjectASP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : Controller
    {
        private readonly AspContext _context;
        public PackageController([FromServices]AspContext context) 
        { 
            _context = context;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<Package> packages = _context.FieldItems
                    .Where(x => x.Field.FieldKey == "Package")
                    .Select(x => new Package
                    {
                        Name = x.Name
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

    }
}
