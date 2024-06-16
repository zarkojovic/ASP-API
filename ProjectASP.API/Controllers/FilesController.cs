﻿using Microsoft.AspNetCore.Mvc;
using ProjectASP.API.DTO;

namespace ProjectASP.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private static IEnumerable<string> allowedExtensions = new List<string>
        {
            ".jpg", ".jpeg", ".png"
        };

        [HttpGet("{fileName}")]
        public IActionResult GetFile(string fileName)
        {
            var path = Path.Combine("wwwroot", "temp", fileName);

            return Ok(new { exists = Path.Exists(path) });
        }

        // POST api/<FilesController>
        [HttpPost]
        public IActionResult Post([FromForm] FIleUploadDto dto)
        {
            var extension = Path.GetExtension(dto.File.FileName);


            if (!allowedExtensions.Contains(extension))
            {
                return new UnsupportedMediaTypeResult();
            }



            var fileName = Guid.NewGuid().ToString() + extension;

            var savePath = Path.Combine("wwwroot", "temp", fileName);

            using var fs = new FileStream(savePath, FileMode.Create);

            dto.File.CopyTo(fs);

            return StatusCode(201, new { file = fileName });
        }
    }
}
