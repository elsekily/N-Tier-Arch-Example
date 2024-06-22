using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;

namespace Movies.DataAccess.Persistence.Configurations;
internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(m => m.Name)
            .HasMaxLength(255)
            .IsRequired();

    }
}