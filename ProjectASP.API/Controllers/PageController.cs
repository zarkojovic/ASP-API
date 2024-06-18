using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.Application.DTO.Pages;
using ProjectASP.Application.UseCases.Commands.Pages;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using ProjectASP.Implementation;

namespace ProjectASP.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PageController : Controller
    {
        private readonly AspContext _context;
        private readonly UseCaseHandler _useCaseHandler;
        public PageController(AspContext context, UseCaseHandler useCaseHandler)
        {
            _context = context;
            _useCaseHandler = useCaseHandler;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Seeder()
        {
            Page p1 = new Page()
            {
                Name = "My Information",
                Route = "/profile",
                Icon = "tabler:profile",
                Role = _context.Roles.First(x => x.Name == "User"),
                Order = 1,
                Categories = _context.Categories.Where(x => new List<string>() { "Personal Information" , "Address"}.Contains(x.Name)).ToList()
            };
            Page p2 = new Page()
            {
                Name = "Documents",
                Route = "/documents",
                Icon = "tabler:documents",
                Role = _context.Roles.First(x => x.Name == "User"),
                Order = 2,
                Categories = _context.Categories.Where(x => x.Name == "Documents").ToList()
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

        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody]CreatePageDTO dto, [FromServices] ICreatePageCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return Created();
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody]UpdatePageDTO dto, [FromServices] IUpdatePageCommand cmd)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return Ok();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {

            Page page = _context.Pages.Find(id);

            if (page == null)
            {
                throw new NullReferenceException("Page not found.");
            }

            if (page.Categories.Count > 0)
            {
                throw new Exception("Page has Categories.");
            }

            _context.Pages.Remove(page);

            _context.SaveChanges();

            return Ok();
        }

    }
}
