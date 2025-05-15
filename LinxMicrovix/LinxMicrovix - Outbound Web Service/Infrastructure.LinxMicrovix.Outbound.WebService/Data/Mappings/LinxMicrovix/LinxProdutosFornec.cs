using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosFornecTrustedMap : IEntityTypeConfiguration<LinxProdutosFornec>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosFornec> builder)
        {
            builder.ToTable("LinxProdutosFornec", "linx_microvix_erp");

            builder.HasKey(e => e.id_prod_forn);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_prod_forn)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.cod_fornecedor)
                .HasColumnType("int");

            builder.Property(e => e.custo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.moeda)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.unidade_compra)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.fator_conversao_compra)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.codauxiliar)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.qtde_embalagem)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prazo_entrega_padrao)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.desconto1)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.desconto2)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.desconto3)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.desconto)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.ipi1)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.diferencial_icms)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.despesas1)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.acrescimo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_custo_substituicao)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.frete1)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.fornecedor_principal)
                .HasColumnType("varchar(1)");

            builder.Property(e => e.excluido)
                .HasColumnType("varchar(1)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxProdutosFornecRawMap : IEntityTypeConfiguration<LinxProdutosFornec>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosFornec> builder)
        {
            builder.ToTable("LinxProdutosFornec", "untreated");

            builder.HasKey(e => e.id_prod_forn);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_prod_forn)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.cod_fornecedor)
                .HasColumnType("int");

            builder.Property(e => e.custo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.moeda)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.unidade_compra)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.fator_conversao_compra)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.codauxiliar)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.qtde_embalagem)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prazo_entrega_padrao)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.desconto1)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.desconto2)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.desconto3)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.desconto)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.ipi1)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.diferencial_icms)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.despesas1)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.acrescimo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_custo_substituicao)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.frete1)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.fornecedor_principal)
                .HasColumnType("varchar(1)");

            builder.Property(e => e.excluido)
                .HasColumnType("varchar(1)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
