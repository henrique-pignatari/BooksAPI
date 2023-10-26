using Books.Domain.Constraints;
using Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infra.Data.EntitiesConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            
            builder.Property(b => b.Name)
                .HasMaxLength(BookConstraints.MaxNameLength)
                .IsRequired();

            builder.Property(b => b.Description)
                .HasMaxLength(BookConstraints.MaxDescriptionLength);

            builder.Property(b => b.TotalPages)
                .HasColumnType("integer");

            builder.Property(b => b.ReadStartDate)
                .HasColumnType("Date");

            builder.Property(b => b.ReadStopDate)
                .HasColumnType("Date");

            builder.Property(b => b.ReadConclusionDate)
                .HasColumnType("Date");

            builder.HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);

            builder.HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);

            builder.HasMany(b => b.Genres)
                .WithMany(bg => bg.Books)
                .UsingEntity<BookGenre>();
            
            builder.HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity<BookAuthor>();

        }
    }
}
