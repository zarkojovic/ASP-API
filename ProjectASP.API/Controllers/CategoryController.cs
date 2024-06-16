﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectASP.DataAccess;
using ProjectASP.Domain;

namespace ProjectASP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly AspContext _context;
        public CategoryController([FromServices]AspContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Seeder()
        {
            Field f1 = _context.Fields.First(x => x.FieldKey == "Date of birth");
            Field f2 = _context.Fields.First(x => x.FieldKey == "Citizenship");
            Field f3 = _context.Fields.First(x => x.FieldKey == "Passport TRC");
            Field f4 = _context.Fields.First(x => x.FieldKey == "Street name/number");
            Field f5 = _context.Fields.First(x => x.FieldKey == "Building no");
            Field f6 = _context.Fields.First(x => x.FieldKey == "Apartment no");
            Field f7 = _context.Fields.First(x => x.FieldKey == "Zip-code");
            Field f8 = _context.Fields.First(x => x.FieldKey == "City");
            Field f9 = _context.Fields.First(x => x.FieldKey == "Country");
            Field f10 = _context.Fields.First(x => x.FieldKey == "Diploma");
            Field f11 = _context.Fields.First(x => x.FieldKey == "Transcript");
            Field f12 = _context.Fields.First(x => x.FieldKey == "Passport");

            Category c1 = new Category()
            {
                Name = "Personal Information",
                Fields = new List<Field>() { f1, f2, f3 }
            };

            Category c2 = new Category()
            {
                Name = "Address",
                Fields = new List<Field>() { f4, f5, f6, f7, f8, f9 }
            };

            Category c3 = new Category()
            {
                Name = "Documents",
                Fields = new List<Field>() { f10, f11, f12 }
            };

            _context.Categories.Add(c1);
            _context.Categories.Add(c2);
            _context.Categories.Add(c3);

            _context.SaveChanges();

            return Ok();
        }
    }
}
