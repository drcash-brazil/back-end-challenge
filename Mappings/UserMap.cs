using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Mappings
{
    public class UserMap: IEntityTypeConfiguration<Users>
    {
                 public void Configure(EntityTypeBuilder<Users> builder)
                        {
                                    builder.ToTable("users");
                                    builder.HasKey(x => x.id);
                                    builder.Property(x => x.id)
                                           .HasDefaultValueSql("(newid())")
                                           .HasMaxLength(50)
                                           .HasColumnType("VARCHAR(50)");
                                    builder.Property(x => x.username)
                                           .IsRequired()
                                           .HasMaxLength(100)
                                           .HasColumnType("VARCHAR(100)");
                                    builder.Property(x => x.password)
                                           .IsRequired()
                                           .HasMaxLength(100)
                                           .HasColumnType("VARCHAR(100)");
                                    builder.Property(x => x.role)
                                           .IsRequired()
                                           .HasMaxLength(100)
                                           .HasColumnType("VARCHAR(100)");


                        }
    
    }
}