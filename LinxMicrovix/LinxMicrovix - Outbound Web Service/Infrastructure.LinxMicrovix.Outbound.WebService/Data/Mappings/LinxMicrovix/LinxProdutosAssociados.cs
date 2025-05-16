using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosAssociadosTrustedMap : IEntityTypeConfiguration<LinxProdutosAssociados>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosAssociados> builder)
        {
            builder.ToTable("LinxProdutosAssociados", "linx_microvix_erp");

            builder.HasKey(e => e.codigoproduto_associado);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigoproduto_associado)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto_origem)
                .HasColumnType("bigint");

            builder.Property(e => e.coeficiente_desconto)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.qtde_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.item_obrigatorio)
                .HasProviderColumnType(LogicalColumnType.Bool);
        }
    }

    public class LinxProdutosAssociadosRawMap : IEntityTypeConfiguration<LinxProdutosAssociados>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosAssociados> builder)
        {
            builder.ToTable("LinxProdutosAssociados", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigoproduto_associado)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto_origem)
                .HasColumnType("bigint");

            builder.Property(e => e.coeficiente_desconto)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.qtde_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.item_obrigatorio)
                .HasProviderColumnType(LogicalColumnType.Bool);
        }
    }
}
