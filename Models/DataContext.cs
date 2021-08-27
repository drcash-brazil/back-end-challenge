using back_end_challenge.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace back_end_challenge.Models
{
  public class DataContext : IdentityDbContext<Users>
  {
    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
    public DbSet<Books> Books { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Authors> Authors { get; set; }
  }
}