using back_end_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end_challenge.Repositories
{
  public class Context : DbContext
  {
    public Context(DbContextOptions<Context> opt) : base(opt)
    {
    }

    public DbSet<Books> Books { get; set; }
  }
}