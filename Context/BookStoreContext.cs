
using BookStoreCrudWebApi.Map;
using BookStoreCrudWebApi.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCrudWebApi.Context
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext>options) : base(options)
        {}

        public DbSet<Autor> autores { get;set;}
        public DbSet<Genero> generos {get; set;}
        public DbSet<Livro> livros { get; set; }
        public DbSet<LivroAutores> livroAutores {get; set;}
        public DbSet<GeneroLivro> generoLivros { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.ApplyConfiguration(new LivroAutoresMap());
            modelBuilder.ApplyConfiguration(new GeneroLivroMap());

        }
        
    }
}