using back_end_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end_challenge.Repositories
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
    }

    public DbSet<Books> Books { get; set; }
  }
}