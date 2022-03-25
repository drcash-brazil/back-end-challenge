using BookStoreCrudWebApi.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreCrudWebApi.Map
{
    public class LivroMap : BaseMap<Livro>
    {
        public LivroMap() : base("tb_livros")
        {}
        public override void Configure(EntityTypeBuilder<Livro> builder)
        {
            base.Configure(builder);
            builder.Property(x=>x.Titulo).HasColumnName("titulo").HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.QuantidadeCopias).HasColumnName("quantidade_copias");
            
        }
    }
}