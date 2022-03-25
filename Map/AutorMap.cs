using Microsoft.EntityFrameworkCore;
using BookStoreCrudWebApi.Models.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreCrudWebApi.Map
{
    public class AutorMap : BaseMap<Autor>
    {
        public AutorMap() : base("tb_autores")
        {}
        public override void Configure(EntityTypeBuilder<Autor> builder)
        {
            base.Configure(builder);
            builder.Property(x =>x.NomeAutor).HasColumnName("nome_autor").HasColumnType("varchar(100)").IsRequired();
           
        }
    }
}