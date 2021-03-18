using DrCash.Teste.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrCash.Teste.Infra.Mappings
{
    public class AutorMapping : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Autores");
        }
    }
}