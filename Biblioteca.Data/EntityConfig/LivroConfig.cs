using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.EntityConfig
{
    public class LivroConfig : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(a => a.LivroId);

            builder.Property(a => a.Titulo)
                   .HasMaxLength(200)
                   .IsRequired();
            
            builder.Property(a => a.Quantidade)
                   .IsRequired();

            builder.Property(a => a.AutorId)
                   .IsRequired();
            
            builder.Property(a => a.GeneroId)
                   .IsRequired();
        }
    }
}
