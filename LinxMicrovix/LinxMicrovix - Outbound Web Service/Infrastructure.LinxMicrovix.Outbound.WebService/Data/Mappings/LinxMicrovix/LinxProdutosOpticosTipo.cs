using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosOpticosTipoTrustedMap : IEntityTypeConfiguration<LinxProdutosOpticosTipo>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosOpticosTipo> builder)
        {
            builder.ToTable("LinxProdutosOpticosTipo", "linx_microvix_erp");

            builder.HasKey(e => e.id_produtos_opticos_tipo);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_produtos_opticos_tipo)
                .HasColumnType("int");

            builder.Property(e => e.tipo)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxProdutosOpticosTipoRawMap : IEntityTypeConfiguration<LinxProdutosOpticosTipo>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosOpticosTipo> builder)
        {
            builder.ToTable("LinxProdutosOpticosTipo", "untreated");

            builder.HasKey(e => e.id_produtos_opticos_tipo);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_produtos_opticos_tipo)
                .HasColumnType("int");

            builder.Property(e => e.tipo)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
