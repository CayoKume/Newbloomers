using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaDificuldadeMap : IEntityTypeConfiguration<LinxPedidosVendaChecklistEntregaDificuldade>
    {
        public void Configure(EntityTypeBuilder<LinxPedidosVendaChecklistEntregaDificuldade> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxPedidosVendaChecklistEntregaDificuldade));

            builder.ToTable("LinxPedidosVendaChecklistEntregaDificuldade");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_checklist_entrega_dificuldades);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_checklist_entrega_dificuldades)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
