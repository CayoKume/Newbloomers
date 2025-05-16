using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxUnidadesMap : IEntityTypeConfiguration<LinxUnidades>
    {
        public void Configure(EntityTypeBuilder<LinxUnidades> builder)
        {
            builder.ToTable("LinxUnidades", "linx_microvix_erp");

            builder.HasKey(e => e.idUnidade);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.idUnidade)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.unidade)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxUnidadesRawMap : IEntityTypeConfiguration<LinxUnidades>
    {
        public void Configure(EntityTypeBuilder<LinxUnidades> builder)
        {
            builder.ToTable("LinxUnidades", "untreated");

            builder.HasKey(e => e.idUnidade);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.idUnidade)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.unidade)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
