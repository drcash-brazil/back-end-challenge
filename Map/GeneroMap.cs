using BookStoreCrudWebApi.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreCrudWebApi.Map
{
    public class GeneroMap : BaseMap<Genero>
    {
        public GeneroMap() : base("tb_generos")
        {}
        public override void Configure(EntityTypeBuilder<Genero> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.genero).HasColumnName("genero").HasColumnType("varchar(100)").IsRequired();
            
        }
    }
}