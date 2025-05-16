using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaLocalTrustedMap : IEntityTypeConfiguration<LinxPedidosVendaChecklistEntregaLocal>
    {
        public void Configure(EntityTypeBuilder<LinxPedidosVendaChecklistEntregaLocal> builder)
        {
            builder.ToTable("LinxPedidosVendaChecklistEntregaLocal", "linx_microvix_erp");

            builder.HasKey(e => e.id_checklist_entrega_local);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_checklist_entrega_local)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxPedidosVendaChecklistEntregaLocalRawMap : IEntityTypeConfiguration<LinxPedidosVendaChecklistEntregaLocal>
    {
        public void Configure(EntityTypeBuilder<LinxPedidosVendaChecklistEntregaLocal> builder)
        {
            builder.ToTable("LinxPedidosVendaChecklistEntregaLocal", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_checklist_entrega_local)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
