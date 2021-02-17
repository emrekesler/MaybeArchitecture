using MaybeArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaybeArchitecture.Infrastructure.Data.EF.Config
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasQueryFilter(e => !e.Deleted);

            builder.Property(e => e.Title)
                   .HasMaxLength(150);

            builder.Property(e => e.Overview)
                  .HasMaxLength(1500);

            builder.Property(e => e.PosterPath)
                  .HasMaxLength(100);

        }
    }
}
