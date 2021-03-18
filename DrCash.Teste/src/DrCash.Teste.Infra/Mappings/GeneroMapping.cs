using DrCash.Teste.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrCash.Teste.Infra.Mappings
{
    public class GeneroMapping : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Generos");
        }
    }
}