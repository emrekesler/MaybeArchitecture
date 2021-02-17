using MaybeArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaybeArchitecture.Infrastructure.Data.EF.Config
{
    internal class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasQueryFilter(e => !e.Deleted);

            builder.Property(e => e.Content)
                  .HasMaxLength(400);
        }
    }
}
