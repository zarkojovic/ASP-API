using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.DataAccess;
using ProjectASP.Domain;

namespace ProjectASP.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StageController : Controller
    {
        private readonly AspContext _context;
        public StageController([FromServices] AspContext context)
        {
            _context = context;
        }

        [HttpGet("seeder")]
        public ActionResult Seeder()
        {
            try
            {
                List<Stage> stages = new List<Stage>();
                List<string> stageNames = ["New Application", "Applied", "Payed", "Missing Documents", "Accepted","Arrived","Rejected","Resigned","Went Back Home"];
                int i = 0;
                foreach (var stageName in stageNames)
                {
                    i++;
                    var stage = new Stage
                    {
                        Name = stageName,
                        Order = i
                    };
                    stages.Add(stage);
                }

                _context.Stages.AddRange(stages);

                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured.");
            }
        }

    }
}
