using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RytnavaBack.Data;
using RytnavaBack.Models;
namespace RytnavaBack.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersControllers : ControllerBase
{
    private readonly RytnavaContext _context;

    public UsersControllers(RytnavaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = user.Id }, user);
    }
}