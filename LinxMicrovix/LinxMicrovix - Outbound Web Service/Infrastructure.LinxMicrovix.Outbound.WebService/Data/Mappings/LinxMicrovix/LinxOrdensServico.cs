using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxOrdensServicoMap : IEntityTypeConfiguration<LinxOrdensServico>
    {
        public void Configure(EntityTypeBuilder<LinxOrdensServico> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxOrdensServico));

            builder.ToTable("LinxOrdensServico");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.numero_os);
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
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.numero_os)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.data_os)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.data_envio_laboratorio)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cancelado)
                .HasColumnType("char(1)");

            builder.Property(e => e.id_laboratorio)
                .HasColumnType("int");

            builder.Property(e => e.id_posicao_os_ramo_optico)
                .HasColumnType("int");

            builder.Property(e => e.compartilhar_hub_laboratorios)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.cod_cliente_os)
                .HasColumnType("int");

            builder.Property(e => e.cod_vendedor)
                .HasColumnType("int");

            builder.Property(e => e.numero_sequencial_antecipacao_financeira)
                .HasColumnType("int");

            builder.Property(e => e.chave_nfe_laboratorio)
                .HasColumnType("varchar(44)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
