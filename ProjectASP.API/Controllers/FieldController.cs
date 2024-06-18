using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ProjectASP.API.DTO;
using ProjectASP.Application.DTO.Fields;
using ProjectASP.Application.UseCases.Commands.Fields;
using ProjectASP.Application.UseCases.Queries.Fields;
using ProjectASP.DataAccess;
using ProjectASP.Domain;
using ProjectASP.Implementation;
using System.Text.Json;

namespace ProjectASP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FieldController : Controller
    {
        private readonly AspContext _context;
        private readonly UseCaseHandler _useCaseHandler;
        public FieldController([FromServices] AspContext context, UseCaseHandler useCaseHandler)
        {
            _context = context;
            _useCaseHandler = useCaseHandler;
        }
        [Authorize]
        [HttpGet("seeder")]
        public async Task<IActionResult> Seeder()
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
        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody]CreateFieldDTO dto, [FromServices]ICreateFieldCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return Created();
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateFieldDTO dto, [FromServices]IUpdateFieldCommand cmd)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return Created();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchFieldsDTO search, [FromServices] IGetFieldsQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, search));
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {

            Field field = _context.Fields.Find(id);

            if (field == null)
            {
                throw new NullReferenceException("Field not found.");
            }

            if (field.Category != null)
            {
                throw new Exception("Field has category.");
            }

            _context.Fields.Remove(field);

            _context.SaveChanges();

            return Ok();
        }



    }
}
