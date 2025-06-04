using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxConfiguracoesTributariasDetalhesSimplificadoMap : IEntityTypeConfiguration<LinxConfiguracoesTributariasDetalhesSimplificado>
    {
        public void Configure(EntityTypeBuilder<LinxConfiguracoesTributariasDetalhesSimplificado> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxConfiguracoesTributariasDetalhesSimplificado));

            builder.ToTable("LinxConfiguracoesTributariasDetalhesSimplificado");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_config_tributaria_detalhe);
                builder.Ignore(x => x.id);
            }
            else
            {
                builder.HasKey(x => x.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

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
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.icms_credito)
                .HasProviderColumnType(EnumTableColumnType.Bool);

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
