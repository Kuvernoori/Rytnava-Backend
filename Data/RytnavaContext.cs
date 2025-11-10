namespace RytnavaBack.Data;
using RytnavaBack.Models;
using Microsoft.EntityFrameworkCore;

public class RytnavaContext : DbContext
{
    public RytnavaContext(DbContextOptions<RytnavaContext> options) : base(options)
    {
        
    }   
    public DbSet<Course> Courses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
}