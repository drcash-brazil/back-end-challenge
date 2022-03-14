using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.EntityConfig
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.HasKey(a => a.GeneroId);

            builder.Property(a => a.Descricao)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.HasMany(g => g.Livros)
                   .WithOne(l => l.Genero)
                   .HasForeignKey(l => l.GeneroId);
        }
    }
}