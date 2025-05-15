using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosTabelasPrecosTrustedMap : IEntityTypeConfiguration<LinxProdutosTabelasPrecos>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosTabelasPrecos> builder)
        {
            builder.ToTable("LinxProdutosTabelasPrecos", "linx_microvix_erp");

            builder.HasKey(e => new { e.cod_produto, e.cnpj_emp, e.id_tabela });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cod_produto)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_tabela)
                .HasColumnType("int");

            builder.Property(e => e.precovenda)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxProdutosTabelasPrecosRawMap : IEntityTypeConfiguration<LinxProdutosTabelasPrecos>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosTabelasPrecos> builder)
        {
            builder.ToTable("LinxProdutosTabelasPrecos", "untreated");

            builder.HasKey(e => new { e.cod_produto, e.cnpj_emp, e.id_tabela });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cod_produto)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_tabela)
                .HasColumnType("int");

            builder.Property(e => e.precovenda)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
