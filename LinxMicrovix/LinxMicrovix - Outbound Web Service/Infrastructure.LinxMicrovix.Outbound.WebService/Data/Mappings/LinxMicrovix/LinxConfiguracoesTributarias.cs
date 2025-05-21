using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxConfiguracoesTributariasMap : IEntityTypeConfiguration<LinxConfiguracoesTributarias>
    {
        public void Configure(EntityTypeBuilder<LinxConfiguracoesTributarias> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxConfiguracoesTributarias));

            builder.ToTable("LinxConfiguracoesTributarias");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.portal);
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

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_config_tributaria)
                .HasColumnType("int");

            builder.Property(e => e.desc_config_tributaria)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.sigla_config_tributaria)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.ativa)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.uf)
                .HasColumnType("varchar(2)");

            builder.Property(e => e.sistema_tributacao)
                .HasColumnType("char(1)");

            builder.Property(e => e.tipo_atividade)
                .HasColumnType("int");

            builder.Property(e => e.id_origem_mercadoria)
                .HasColumnType("int");

            builder.Property(e => e.utiliza_uso_consumo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.id_classificacao_cest_produto)
                .HasColumnType("int");

            builder.Property(e => e.codigo_ws)
                .HasColumnType("varchar(50)");
        }
    }
}
