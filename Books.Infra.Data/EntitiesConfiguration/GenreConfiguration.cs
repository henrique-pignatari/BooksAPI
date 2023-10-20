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
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g =>  g.Id);

            builder.Property(g => g.Name)
                .HasMaxLength(GenreConstraints.MaxNameLength)
                .IsRequired();

            builder.HasMany(g => g.Books)
                .WithMany(b => b.Genres)
                .UsingEntity<BookGenre>();
        }
    }
}
