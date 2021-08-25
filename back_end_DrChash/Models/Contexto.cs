using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end_DrChash.Models;

namespace back_end_DrChash.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {
            Database.EnsureCreated();
        }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Autor> Autor { get; set; }

        public DbSet<Genero> Genero { get; set; }
    }
}
