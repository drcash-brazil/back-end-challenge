using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Mappings
{
            public class AuthorMap : IEntityTypeConfiguration<Authors>
            {
                        public void Configure(EntityTypeBuilder<Authors> builder)
                        {
                                    builder.ToTable("authors");
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