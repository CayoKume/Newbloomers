using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxConfiguracoesTributariasDetalhesSimplificadoTrustedMap : IEntityTypeConfiguration<LinxConfiguracoesTributariasDetalhesSimplificado>
    {
        public void Configure(EntityTypeBuilder<LinxConfiguracoesTributariasDetalhesSimplificado> builder)
        {
            builder.ToTable("LinxConfiguracoesTributariasDetalhesSimplificado", "linx_microvix_erp");

            builder.HasKey(e => e.id_config_tributaria_detalhe);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_config_tributaria)
                .HasColumnType("int");

            builder.Property(e => e.cod_natureza_operacao)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.id_classe_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.id_cst_icms_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.id_csosn_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.id_cfop_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.ipi_credito)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.icms_credito)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.aliq_icms)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.perc_reducao_icms)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliquota_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.margem_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxConfiguracoesTributariasDetalhesSimplificadoRawMap : IEntityTypeConfiguration<LinxConfiguracoesTributariasDetalhesSimplificado>
    {
        public void Configure(EntityTypeBuilder<LinxConfiguracoesTributariasDetalhesSimplificado> builder)
        {
            builder.ToTable("LinxConfiguracoesTributariasDetalhesSimplificado", "untreated");

            builder.HasKey(e => e.id_config_tributaria_detalhe);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_config_tributaria)
                .HasColumnType("int");

            builder.Property(e => e.cod_natureza_operacao)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.id_classe_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.id_cst_icms_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.id_csosn_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.id_cfop_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.ipi_credito)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.icms_credito)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.aliq_icms)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.perc_reducao_icms)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliquota_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.margem_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
