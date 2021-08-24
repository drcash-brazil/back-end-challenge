using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Mappings
{
    public class OrderBookMap: IEntityTypeConfiguration<OrderBooks>
    {
                 public void Configure(EntityTypeBuilder<OrderBooks> builder)
                        {
                                    builder.ToTable("orderBooks");
                                    builder.HasKey(x => x.id);
                                    builder.Property(x => x.id)
                                           .HasDefaultValueSql("(newid())")
                                           .HasMaxLength(50)
                                           .HasColumnType("VARCHAR(50)");
                                    builder.Property(x => x.orderDate)
                                           .IsRequired()
                                           .HasColumnType("DATETIME");
                                    builder.Property(x => x.orderQuantity)
                                           .IsRequired()
                                           .HasColumnType("BIGINT");
                                    builder.Property(x => x.bookId)
                                           .IsRequired()
                                           .HasMaxLength(50)
                                           .HasColumnType("VARCHAR(50)");
                                    builder.Property(x => x.status)
                                           .IsRequired()
                                           .HasDefaultValue("In process")
                                           .HasMaxLength(50)
                                           .HasColumnType("VARCHAR(50)");


                        }
    
    }

}