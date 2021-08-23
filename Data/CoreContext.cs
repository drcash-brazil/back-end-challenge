using back_end_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end_challenge.Data
{
  public class CoreContext : DbContext
  {
    public CoreContext(DbContextOptions<CoreContext> opt) : base(opt)
    {
    }

    public DbSet<Books> Books { get; set; }
  }
}