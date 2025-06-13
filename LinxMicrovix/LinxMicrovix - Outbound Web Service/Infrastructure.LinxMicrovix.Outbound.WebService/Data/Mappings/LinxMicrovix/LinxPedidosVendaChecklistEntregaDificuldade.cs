using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaDificuldadeMap : IEntityTypeConfiguration<LinxPedidosVendaChecklistEntregaDificuldade>
    {
        public void Configure(EntityTypeBuilder<LinxPedidosVendaChecklistEntregaDificuldade> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxPedidosVendaChecklistEntregaDificuldade));

            builder.ToTable("LinxPedidosVendaChecklistEntregaDificuldade");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_checklist_entrega_dificuldades);
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

            builder.Property(e => e.id_checklist_entrega_dificuldades)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
