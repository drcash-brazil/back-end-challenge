using DrCash.Teste.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrCash.Teste.Infra.Mappings
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Titulo)
                .IsRequired()
                .HasColumnType("varchar(200)");


            // 1 : 1 => Livro : Genero
            builder.HasOne(l => l.Genero)
                .WithOne(g => g.Livro);

            // 1 : 1 => Livro : Autor
            builder.HasOne(l => l.Autor)
                .WithOne(a => a.Livro);

            builder.ToTable("Livros");
        }
    }
}