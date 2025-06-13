using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaMap : IEntityTypeConfiguration<LinxDevolucaoRemanejoFabrica>
    {
        public void Configure(EntityTypeBuilder<LinxDevolucaoRemanejoFabrica> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxDevolucaoRemanejoFabrica));

            builder.ToTable("LinxDevolucaoRemanejoFabrica");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_devolucao_remanejo_fabrica);
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

            builder.Property(e => e.id_devolucao_remanejo_fabrica)
                .HasColumnType("int");

            builder.Property(e => e.id_devolucao_remanejo_fabrica_tipo)
                .HasColumnType("int");

            builder.Property(e => e.id_motivo_devolucao_fabrica)
                .HasColumnType("int");

            builder.Property(e => e.id_deposito)
                .HasColumnType("int");

            builder.Property(e => e.id_devolucao_remanejo_fabrica_status)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.fornecedor)
                .HasColumnType("int");

            builder.Property(e => e.cfop)
                .HasColumnType("char(10)");

            builder.Property(e => e.serie)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.codigo_solicitacao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.data_solicitacao)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
