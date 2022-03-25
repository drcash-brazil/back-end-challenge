using BookStoreCrudWebApi.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreCrudWebApi.Map
{
    public class LivroAutoresMap : IEntityTypeConfiguration<LivroAutores>
    {
        public  void Configure(EntityTypeBuilder<LivroAutores> builder)
        {
            builder.ToTable("tb_livros_autores");
            builder.Property(x=>x.livroId).HasColumnName("livro_id").IsRequired();
            builder.Property(x=>x.autorId).HasColumnName("autor_id").IsRequired();
            builder.HasKey(x => new {x.livroId, x.autorId});
            builder.HasOne(x => x.Livro)
                .WithMany(x => x.LivroAutores)
                .HasForeignKey(x => x.livroId);
            
            builder.HasOne(x => x.Autor)
                .WithMany(x => x.LivroAutores)
                .HasForeignKey(x => x.autorId);
        }
    }
}