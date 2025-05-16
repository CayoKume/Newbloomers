using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisValoresTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosCamposAdicionaisValores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCamposAdicionaisValores> builder)
        {
            builder.ToTable("B2CConsultaProdutosCamposAdicionaisValores", "linx_microvix_commerce");

            builder.HasKey(e => e.id_campo_valor);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_campo_valor)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.id_campo_detalhe)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }

    public class B2CConsultaProdutosCamposAdicionaisValoresRawMap : IEntityTypeConfiguration<B2CConsultaProdutosCamposAdicionaisValores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCamposAdicionaisValores> builder)
        {
            builder.ToTable("B2CConsultaProdutosCamposAdicionaisValores", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_campo_valor)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.id_campo_detalhe)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
