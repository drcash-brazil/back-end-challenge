using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Books>
    {
         public void Configure(EntityTypeBuilder<Books> builder)
                        {
                                    builder.ToTable("books");
                                    builder.HasKey(x => x.id);
                                    builder.Property(x => x.id)
                                           .HasDefaultValueSql("(newid())")
                                           .HasMaxLength(50)
                                           .HasColumnType("VARCHAR(50)");
                                    builder.Property(x => x.genreId)
                                          
                                           .HasMaxLength(50)
                                           .HasColumnType("VARCHAR(50)");
                                    builder.Property(x => x.title)
                                           .IsRequired()
                                           .HasMaxLength(50)
                                           .HasColumnType("VARCHAR(50)");
                                   builder.Property(x => x.quantity)
                                           .IsRequired()
                                           .HasColumnType("BIGINT");
                                   builder.Property(x => x.authorId)
                                          .HasMaxLength(50)
                                          .HasColumnType("VARCHAR(50)");
                                   builder.Property(x => x.price)
                                          .IsRequired()
                                          .HasColumnType("FLOAT");      
                                   
               
                

                        }
    }
}