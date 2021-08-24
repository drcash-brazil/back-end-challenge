using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BackEnd.Models;

namespace BackEnd.Mappings
{
    public class GenreMap : IEntityTypeConfiguration<Generous>
    {
         public void Configure(EntityTypeBuilder<Generous> builder)
                        {
                                    builder.ToTable("generous");
                                    builder.HasKey(x => x.id);
                                    builder.Property(x => x.id)
                                           .HasDefaultValueSql("(newid())")
                                           .HasMaxLength(50)
                                           .HasColumnType("VARCHAR(50)");
                                    builder.Property(x => x.name)
                                           .IsRequired()
                                           .HasMaxLength(100)
                                           .HasColumnType("VARCHAR(100)");


                        }
    
    }
}