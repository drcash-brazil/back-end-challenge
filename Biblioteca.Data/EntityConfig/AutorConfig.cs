using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.EntityConfig
{
    public class AutorConfig : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(a => a.AutorId);

            builder.Property(a => a.Nome)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.HasMany(a => a.Livros)
                   .WithOne(l => l.Autor)
                   .HasForeignKey(l => l.AutorId);
        }
    }
}