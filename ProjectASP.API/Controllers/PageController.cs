using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.DataAccess;
using ProjectASP.Domain;

namespace ProjectASP.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PageController : Controller
    {
        private readonly AspContext _context;
        public PageController(AspContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Seeder()
        {
            Page p1 = new Page()
            {
                Name = "My Information",
                Route = "/profile",
                Icon = "tabler:profile",
                Role = _context.Roles.First(x => x.Name == "User"),
                Order = 1
            };
            Page p2 = new Page()
            {
                Name = "Documents",
                Route = "/documents",
                Icon = "tabler:documents",
                Role = _context.Roles.First(x => x.Name == "User"),
                Order = 2
            };
            Page p3 = new Page()
            {
                Name = "Applications",
                Route = "/applications",
                Icon = "tabler:application",
                Role = _context.Roles.First(x => x.Name == "User"),
                Order = 3
            };
            Page p4 = new Page()
            {
                Name = "Visa",
                Route = "/visa",
                Icon = "tabler:visa",
                Role = _context.Roles.First(x => x.Name == "User"),
                Order = 4
            };

            _context.Pages.Add(p1);
            _context.Pages.Add(p2);
            _context.Pages.Add(p3);
            _context.Pages.Add(p4);

            _context.SaveChanges();

            return Ok();
        }

    }
}
