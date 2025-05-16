using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaDificuldadeTrustedMap : IEntityTypeConfiguration<LinxPedidosVendaChecklistEntregaDificuldade>
    {
        public void Configure(EntityTypeBuilder<LinxPedidosVendaChecklistEntregaDificuldade> builder)
        {
            builder.ToTable("LinxPedidosVendaChecklistEntregaDificuldade", "linx_microvix_erp");

            builder.HasKey(e => e.id_checklist_entrega_dificuldades);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_checklist_entrega_dificuldades)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxPedidosVendaChecklistEntregaDificuldadeRawMap : IEntityTypeConfiguration<LinxPedidosVendaChecklistEntregaDificuldade>
    {
        public void Configure(EntityTypeBuilder<LinxPedidosVendaChecklistEntregaDificuldade> builder)
        {
            builder.ToTable("LinxPedidosVendaChecklistEntregaDificuldade", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_checklist_entrega_dificuldades)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
