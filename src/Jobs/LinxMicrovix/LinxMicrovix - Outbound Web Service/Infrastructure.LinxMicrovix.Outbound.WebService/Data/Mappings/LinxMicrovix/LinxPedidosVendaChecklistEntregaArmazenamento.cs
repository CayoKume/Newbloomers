using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaArmazenamentoMap : IEntityTypeConfiguration<LinxPedidosVendaChecklistEntregaArmazenamento>
    {
        public void Configure(EntityTypeBuilder<LinxPedidosVendaChecklistEntregaArmazenamento> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxPedidosVendaChecklistEntregaArmazenamento));

            builder.ToTable("LinxPedidosVendaChecklistEntregaArmazenamento");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_checklist_entrega_armazenamento);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_checklist_entrega_armazenamento)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("int");
        }
    }
}
