using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoVendasMap : IEntityTypeConfiguration<LinxTrocaUnificadaResumoVendas>
    {
        public void Configure(EntityTypeBuilder<LinxTrocaUnificadaResumoVendas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxTrocaUnificadaResumoVendas));

            builder.ToTable("LinxTrocaUnificadaResumoVendas");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_troca_unificada_resumo_vendas);
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

            builder.Property(e => e.id_troca_unificada_resumo_vendas)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.token)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.serie)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.data_venda)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.documento_cliente)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.venda_cancelada)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
