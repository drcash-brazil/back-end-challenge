using back_end_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end_challenge.Models
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
    }

    public DbSet<Books> Books { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Authors> Authors { get; set; }
  }
}