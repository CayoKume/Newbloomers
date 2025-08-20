using Domain.Core.Entities.Auditing;
using Domain.Core.Enums;
using Infrastructure.Core.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Core.Data.Mappings
{
    public class ConfigsMap : IEntityTypeConfiguration<Config>
    {
        public void Configure(EntityTypeBuilder<Config> builder)
        {
            builder.ToTable("Configs");

            builder.HasKey(e => e.IdJobConfig);

            builder.Property(e => e.IdJobConfig)
                .HasColumnType("int");

            builder.Property(e => e.IdJob)
                .HasColumnType("int");

            builder.Property(e => e.MinutesInterval)
                .HasColumnType("int");

            builder.Property(e => e.IsActive)
                .HasProviderColumnType(EnumTableColumnType.Bool);
        }
    }
}
