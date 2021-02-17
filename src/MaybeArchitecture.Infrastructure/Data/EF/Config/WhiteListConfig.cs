using MaybeArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaybeArchitecture.Infrastructure.Data.EF.Config
{
    public class WhiteListConfig : IEntityTypeConfiguration<WhiteList>
    {
        public void Configure(EntityTypeBuilder<WhiteList> builder)
        {
            builder.HasQueryFilter(e => !e.Deleted);

            builder.Property(e => e.Name)
                  .HasMaxLength(30)
                  .IsRequired();

        }
    }
}
