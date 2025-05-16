using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCupomDescontoVendasMap : IEntityTypeConfiguration<LinxCupomDescontoVendas>
    {
        public void Configure(EntityTypeBuilder<LinxCupomDescontoVendas> builder)
        {
            builder.ToTable("LinxCupomDescontoVendas", "linx_microvix_erp");

            builder.HasKey(e => e.id_cupom_desconto_vendas);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.id_cupom_desconto_vendas)
                .HasColumnType("int");

            builder.Property(e => e.id_cupom_desconto)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxCupomDescontoVendasRawMap : IEntityTypeConfiguration<LinxCupomDescontoVendas>
    {
        public void Configure(EntityTypeBuilder<LinxCupomDescontoVendas> builder)
        {
            builder.ToTable("LinxCupomDescontoVendas", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.id_cupom_desconto_vendas)
                .HasColumnType("int");

            builder.Property(e => e.id_cupom_desconto)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
