using System.Diagnostics.CodeAnalysis;
using BibliotecaDrCash.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BibliotecaDrCash{
    public class AppDbContext:DbContext{
        public AppDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autores {get;set;}
        public DbSet<Genero> Generos {get;set;}
        public DbSet<Livro> Livros {get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Livro>().Property(l => l.Titulo).IsRequired();
            modelBuilder.Entity<Livro>().Property(l => l.NumCopias).HasDefaultValue<int>(0);
            modelBuilder.Entity<Livro>().HasMany(l => l.Autores).WithMany( la => la.Livros);
            modelBuilder.Entity<Livro>().HasMany(l => l.Generos).WithMany(lg => lg.Livros);

            modelBuilder.Entity<Genero>().Property(g => g.Nome).IsRequired();
            modelBuilder.Entity<Autor>().Property(g => g.Nome).IsRequired();
        }
    }

}