using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaLocalMap : IEntityTypeConfiguration<LinxPedidosVendaChecklistEntregaLocal>
    {
        public void Configure(EntityTypeBuilder<LinxPedidosVendaChecklistEntregaLocal> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxPedidosVendaChecklistEntregaLocal));

            builder.ToTable("LinxPedidosVendaChecklistEntregaLocal");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_checklist_entrega_local);
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

            builder.Property(e => e.id_checklist_entrega_local)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
