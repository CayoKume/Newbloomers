using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosOpticosTipoAroTrustedMap : IEntityTypeConfiguration<LinxProdutosOpticosTipoAro>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosOpticosTipoAro> builder)
        {
            builder.ToTable("LinxProdutosOpticosTipoAro", "linx_microvix_erp");

            builder.HasKey(e => e.id_tipo_aro);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_tipo_aro)
                .HasColumnType("int");

            builder.Property(e => e.tipo_aro)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxProdutosOpticosTipoAroRawMap : IEntityTypeConfiguration<LinxProdutosOpticosTipoAro>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosOpticosTipoAro> builder)
        {
            builder.ToTable("LinxProdutosOpticosTipoAro", "untreated");

            builder.HasKey(e => e.id_tipo_aro);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_tipo_aro)
                .HasColumnType("int");

            builder.Property(e => e.tipo_aro)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
