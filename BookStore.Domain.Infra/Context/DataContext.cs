using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Domain.Infra.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }

    public DbSet<Book>? Book { get; set; }
    public DbSet<Author>? Author { get; set; }
    public DbSet<Genre>? Genre { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Author props
        modelBuilder.Entity<Author>().ToTable("Author");
        modelBuilder.Entity<Author>().Property(x => x.Id);
        modelBuilder.Entity<Author>().Property(x => x.Name)
            .HasMaxLength(80)
            .HasColumnType("varchar(80)");
        modelBuilder.Entity<Author>().HasIndex(b => b.Name);

        // Genre props
        modelBuilder.Entity<Genre>().ToTable("Genre");
        modelBuilder.Entity<Genre>().Property(x => x.Id);
        modelBuilder.Entity<Genre>().Property(x => x.Name)
            .HasMaxLength(80)
            .HasColumnType("varchar(80)");
        modelBuilder.Entity<Genre>().HasIndex(b => b.Name);

        // Book props
        modelBuilder.Entity<Book>().ToTable("Book");
        modelBuilder.Entity<Book>().Property(x => x.Id);
        modelBuilder.Entity<Book>().Property(x => x.Title)
            .HasMaxLength(80)
            .HasColumnType("varchar(80)");

        modelBuilder.Entity<Book>().Property(x => x.NumberOfCopies)
            .HasColumnType("int");

        modelBuilder.Entity<Genre>()
            .HasOne(p => p.Book)
            .WithOne(b => b.Genre)
            .HasForeignKey<Book>(p => p.Id);

        modelBuilder.Entity<Author>()
            .HasOne(p => p.Book)
            .WithOne(b => b.Author)
            .HasForeignKey<Book>(p => p.Id);
    }
}