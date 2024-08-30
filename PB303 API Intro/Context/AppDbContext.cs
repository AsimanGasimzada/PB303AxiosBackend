using Microsoft.EntityFrameworkCore;
using PB303_API_Intro.Models;

namespace PB303_API_Intro.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {

    }

    public DbSet<User> Users { get; set; } = null!;
}
