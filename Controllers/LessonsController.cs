using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RytnavaBack.Data;
using RytnavaBack.Models;
namespace RytnavaBack.Controllers;

[ApiController]
[Route("api/[controller]")]

public class LessonsController : ControllerBase
{
    private readonly RytnavaContext _context;

    public LessonsController(RytnavaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var lessons = await _context.Lessons.ToListAsync();
        return Ok(lessons);
    }

    [HttpGet("bycourse/{courseId}")]
    public async Task<IActionResult> GetByCourseId(int courseid)
    {
        var lessons = await _context.Lessons.Where(l => l.CourseId == courseid).ToListAsync();
        return Ok(lessons);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Lesson lesson)
    {
        _context.Lessons.Add(lesson);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = lesson.Id }, lesson);
    }
    
}