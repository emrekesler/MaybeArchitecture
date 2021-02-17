using MaybeArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaybeArchitecture.Infrastructure.Data.EF.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasQueryFilter(e => !e.Deleted);

            builder.Property(e => e.Code)
                   .HasMaxLength(30);

            builder.Property(e => e.Name)
                   .HasMaxLength(50)
                   .HasDefaultValue(string.Empty)
                   .IsRequired(false);
        }
    }
}
