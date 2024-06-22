using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;

namespace Movies.DataAccess.Persistence.Configurations;

internal class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.Property(m => m.Name)
            .HasMaxLength(255)
            .IsRequired();

    }
}