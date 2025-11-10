using Microsoft.AspNetCore.Mvc;
using RytnavaBack.Data;
using RytnavaBack.Models;

namespace RytnavaBack.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly RytnavaContext _context;

           public CoursesController(RytnavaContext context)
           {
               _context = context;
           }

           [HttpGet]
           public IActionResult GetAll()
           {
               return Ok(_context.Courses.ToList());
           }

           [HttpPost]
           public IActionResult Create(Course course)
           {
               _context.Courses.Add(course);
               _context.SaveChanges();
               return CreatedAtAction(nameof(GetAll), new{ id = course.Id}, course);
           }
    }