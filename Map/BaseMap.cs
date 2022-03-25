using BookStoreCrudWebApi.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreCrudWebApi.Map
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : Base
    {
        private readonly string _nomeTabela;
        public BaseMap(string nomeTabela)
        {
            _nomeTabela = nomeTabela;
        }
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if(!string.IsNullOrEmpty(_nomeTabela)) builder.ToTable(_nomeTabela);

            builder.HasKey( X => X.Id);
            builder.Property(x => x.Id).HasColumnName("id").HasDefaultValue("newId()");
        }
    }
}