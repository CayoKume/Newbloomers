using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxConfiguracoesTributariasMap : IEntityTypeConfiguration<LinxConfiguracoesTributarias>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxConfiguracoesTributarias> builder)
        {
            builder.ToTable("LinxConfiguracoesTributarias");

            builder.HasKey(e => e.portal);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

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
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.uf)
                .HasColumnType("varchar(2)");

            builder.Property(e => e.sistema_tributacao)
                .HasColumnType("char(1)");

            builder.Property(e => e.tipo_atividade)
                .HasColumnType("int");

            builder.Property(e => e.id_origem_mercadoria)
                .HasColumnType("int");

            builder.Property(e => e.utiliza_uso_consumo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.id_classificacao_cest_produto)
                .HasColumnType("int");

            builder.Property(e => e.codigo_ws)
                .HasColumnType("varchar(50)");
        }
    }
}
