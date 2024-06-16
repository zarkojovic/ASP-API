using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.API.DTO;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using System.Text.Json;

namespace ProjectASP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly AspContext _context;
        public HomeController([FromServices]AspContext context)
        {
            _context = context;
        }

        // GET: HomeController
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            string filePath = "Seeders/Fields.json"; // Update with your actual file path
            string jsonContent;

            try
            {
                // Read the JSON file content
                jsonContent = await System.IO.File.ReadAllTextAsync(filePath);

                // Deserialize the JSON content into a list of FieldJsonDTO objects
                var fields = JsonSerializer.Deserialize<List<FieldJsonDTO>>(jsonContent);

                // Project the deserialized FieldJsonDTO objects into Field entities using LINQ
                var newFields = fields.Select(field => new Field
                {
                    Name = field.title,
                    Type = field.type,
                    FieldKey = field.formLabel ?? field.title,
                    Items = field.items.Select(item => new FieldItem
                    {
                        Value = item.ID,
                        Name = item.VALUE
                    }).ToList()
                }).ToList();

                //// Add the projected Field entities to the database context
                _context.Fields.AddRange(newFields);

                //// Save changes to the database
                await _context.SaveChangesAsync();
                // Pass the deserialized objects to the view
                return Ok();
            }
            catch (JsonException jsonEx)
            {
                // Handle JSON deserialization errors
                Console.WriteLine($"JSON error: {jsonEx.Message}");
                return StatusCode(500, "Error parsing JSON data");
            }
            catch (Exception ex)
            {
                // Handle other errors
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }


        }

    }
}
