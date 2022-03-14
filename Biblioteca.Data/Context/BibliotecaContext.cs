using Biblioteca.Data.EntityConfig;
using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Data.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {
        }

        DbSet<Autor> Autor { get; set; }
        DbSet<Genero> Genero { get; set; }
        DbSet<Livro> Livro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfiguration(new AutorConfig());
            modelBuilder.ApplyConfiguration(new GeneroConfig());
            modelBuilder.ApplyConfiguration(new LivroConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}