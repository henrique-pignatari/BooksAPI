using Books.Domain.Entities;
using Books.Domain.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infra.Data.EntitiesConfiguration
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(PublisherConstraints.MaxNameLength)
                .IsRequired();

            builder.Property(p => p.Logo)
                .HasMaxLength(PublisherConstraints.MaxLogoLength);

            builder.HasMany(p => p.Books)
                .WithOne(p => p.Publisher);
        }
    }
}
