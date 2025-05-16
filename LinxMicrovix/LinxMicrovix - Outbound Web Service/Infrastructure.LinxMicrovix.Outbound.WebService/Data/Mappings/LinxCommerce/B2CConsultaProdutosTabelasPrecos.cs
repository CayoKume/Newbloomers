using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosTabelasPrecosTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosTabelasPrecos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosTabelasPrecos> builder)
        {
            builder.ToTable("B2CConsultaProdutosTabelasPrecos", "linx_microvix_commerce");

            builder.HasKey(e => e.id_prod_tab_preco);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_prod_tab_preco)
                .HasColumnType("int");

            builder.Property(e => e.id_tabela)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.precovenda)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }

    public class B2CConsultaProdutosTabelasPrecosRawMap : IEntityTypeConfiguration<B2CConsultaProdutosTabelasPrecos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosTabelasPrecos> builder)
        {
            builder.ToTable("B2CConsultaProdutosTabelasPrecos", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_prod_tab_preco)
                .HasColumnType("int");

            builder.Property(e => e.id_tabela)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.precovenda)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
