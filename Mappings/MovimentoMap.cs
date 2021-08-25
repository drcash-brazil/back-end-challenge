using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Mappings
{
    public class MovementMap: IEntityTypeConfiguration<Movement>
    {
         public void Configure(EntityTypeBuilder<Movement> builder)
                        {
                                    builder.ToTable("movement");
                                    builder.HasKey(x => x.id);
                                    builder.Property(x => x.id)
                                           .HasDefaultValueSql("(newid())")
                                           .HasMaxLength(50)
                                           .HasColumnType("VARCHAR(50)");
                                    builder.Property(x => x.dateCreated)
                                           .IsRequired()
                                           .HasColumnType("DATETIME");
                                    builder.Property(x => x.value)
                                           .IsRequired()
                                           .HasColumnType("FLOAT");
                                    builder.Property(x => x.bookId)
                                           .HasMaxLength(50)
                                           .HasColumnType("VARCHAR(50)");
                                    builder.Property(x => x.operation)
                                           .HasMaxLength(50)
                                           .HasColumnType("VARCHAR(50)");       
                                    builder.Property(x => x.quantity)
                                           .IsRequired()
                                           .HasColumnType("BIGINT");


                        }
    
    }
}