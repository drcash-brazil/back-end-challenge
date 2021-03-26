using DrCashChallenge.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCashChallenge.Data.Mappings
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Title)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.Property(l => l.NumberOfCopies)
                .IsRequired()
                .HasColumnType("int");

            builder.HasMany(l => l.Genres)
                .WithMany(g => g.Books);

            builder.HasMany(l => l.Authors)
                .WithMany(a => a.Books);

            builder.ToTable("Books");
        }
    }
}
