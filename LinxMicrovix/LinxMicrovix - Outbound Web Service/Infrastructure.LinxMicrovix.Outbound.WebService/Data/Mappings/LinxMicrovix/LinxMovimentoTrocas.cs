using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoTrocasTrustedMap : IEntityTypeConfiguration<LinxMovimentoTrocas>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoTrocas> builder)
        {
            builder.ToTable("LinxMovimentoTrocas", "linx_microvix_erp");

            builder.HasKey(e => new {
                e.cnpj_emp,
                e.num_vale,
                e.doc_origem,
                e.doc_venda,
                e.doc_venda_origem,
                e.cod_cliente
            });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.num_vale)
                .HasColumnType("bigint");

            builder.Property(e => e.valor_vale)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.motivo)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.doc_origem)
                .HasColumnType("int");

            builder.Property(e => e.serie_origem)
                .HasColumnType("char(10)");

            builder.Property(e => e.doc_venda)
                .HasColumnType("int");

            builder.Property(e => e.serie_venda)
                .HasColumnType("char(10)");

            builder.Property(e => e.excluido)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.desfazimento)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.vale_cod_cliente)
                .HasColumnType("int");

            builder.Property(e => e.vale_codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.id_vale_ordem_servico_externa)
                .HasColumnType("int");

            builder.Property(e => e.doc_venda_origem)
                .HasColumnType("int");

            builder.Property(e => e.serie_venda_origem)
                .HasColumnType("char(10)");

            builder.Property(e => e.cod_cliente)
                .HasColumnType("int");
        }
    }

    public class LinxMovimentoTrocasRawMap : IEntityTypeConfiguration<LinxMovimentoTrocas>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoTrocas> builder)
        {
            builder.ToTable("LinxMovimentoTrocas", "untreated");

            builder.HasKey(e => new { 
                e.cnpj_emp, 
                e.num_vale, 
                e.doc_origem, 
                e.doc_venda, 
                e.doc_venda_origem, 
                e.cod_cliente 
            });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.num_vale)
                .HasColumnType("bigint");

            builder.Property(e => e.valor_vale)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.motivo)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.doc_origem)
                .HasColumnType("int");

            builder.Property(e => e.serie_origem)
                .HasColumnType("char(10)");

            builder.Property(e => e.doc_venda)
                .HasColumnType("int");

            builder.Property(e => e.serie_venda)
                .HasColumnType("char(10)");

            builder.Property(e => e.excluido)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.desfazimento)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.vale_cod_cliente)
                .HasColumnType("int");

            builder.Property(e => e.vale_codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.id_vale_ordem_servico_externa)
                .HasColumnType("int");

            builder.Property(e => e.doc_venda_origem)
                .HasColumnType("int");

            builder.Property(e => e.serie_venda_origem)
                .HasColumnType("char(10)");

            builder.Property(e => e.cod_cliente)
                .HasColumnType("int");
        }
    }
}
