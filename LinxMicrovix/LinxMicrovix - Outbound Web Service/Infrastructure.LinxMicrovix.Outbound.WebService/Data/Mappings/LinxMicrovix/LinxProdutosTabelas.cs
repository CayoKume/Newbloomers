using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosTabelasTrustedMap : IEntityTypeConfiguration<LinxProdutosTabelas>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosTabelas> builder)
        {
            builder.ToTable("LinxProdutosTabelas", "linx_microvix_erp");

            builder.HasKey(e => new { e.id_tabela, e.cnpj_emp, e.tipo_tabela });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_tabela)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.nome_tabela)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativa)
                .HasColumnType("char(1)");

            builder.Property(e => e.timestamp)
                .HasColumnType("int");

            builder.Property(e => e.tipo_tabela)
                .HasColumnType("char(1)");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");
        }
    }

    public class LinxProdutosTabelasRawMap : IEntityTypeConfiguration<LinxProdutosTabelas>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosTabelas> builder)
        {
            builder.ToTable("LinxProdutosTabelas", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_tabela)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.nome_tabela)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativa)
                .HasColumnType("char(1)");

            builder.Property(e => e.timestamp)
                .HasColumnType("int");

            builder.Property(e => e.tipo_tabela)
                .HasColumnType("char(1)");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");
        }
    }
}
