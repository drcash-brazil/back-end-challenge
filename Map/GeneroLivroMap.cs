using BookStoreCrudWebApi.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreCrudWebApi.Map
{
    public class GeneroLivroMap: IEntityTypeConfiguration<GeneroLivro>
    {
        public  void Configure(EntityTypeBuilder<GeneroLivro> builder)
        {
            builder.ToTable("tb_genero_livros");
            builder.Property(x=>x.livroId).HasColumnName("livro_id").IsRequired();
            builder.Property(x=>x.generoId).HasColumnName("genero_id").IsRequired();
            builder.HasKey(x => new {x.livroId, x.generoId});
            builder.HasOne(x => x.Livro)
                .WithMany(x => x.GeneroLivro)
                .HasForeignKey(x => x.livroId);
            
            builder.HasOne(x => x.Genero)
                .WithMany(x => x.GeneroLivro)
                .HasForeignKey(x => x.generoId);
        }
    }
}