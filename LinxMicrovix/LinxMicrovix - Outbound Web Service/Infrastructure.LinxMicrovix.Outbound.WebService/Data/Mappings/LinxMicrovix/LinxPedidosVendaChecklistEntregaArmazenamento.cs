using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaArmazenamentoTrustedMap : IEntityTypeConfiguration<LinxPedidosVendaChecklistEntregaArmazenamento>
    {
        public void Configure(EntityTypeBuilder<LinxPedidosVendaChecklistEntregaArmazenamento> builder)
        {
            builder.ToTable("LinxPedidosVendaChecklistEntregaArmazenamento", "linx_microvix_erp");

            builder.HasKey(e => e.id_checklist_entrega_armazenamento);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_checklist_entrega_armazenamento)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("int");
        }
    }

    public class LinxPedidosVendaChecklistEntregaArmazenamentoRawMap : IEntityTypeConfiguration<LinxPedidosVendaChecklistEntregaArmazenamento>
    {
        public void Configure(EntityTypeBuilder<LinxPedidosVendaChecklistEntregaArmazenamento> builder)
        {
            builder.ToTable("LinxPedidosVendaChecklistEntregaArmazenamento", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_checklist_entrega_armazenamento)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("int");
        }
    }
}
