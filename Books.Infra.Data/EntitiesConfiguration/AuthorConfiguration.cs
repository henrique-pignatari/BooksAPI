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
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasMaxLength(AuthorConstraints.MaxNameLength)
                .IsRequired();

            builder.HasMany(a => a.Books)
                .WithMany(b => b.Authors)
                .UsingEntity<BookAuthor>();

        }
    }
}
