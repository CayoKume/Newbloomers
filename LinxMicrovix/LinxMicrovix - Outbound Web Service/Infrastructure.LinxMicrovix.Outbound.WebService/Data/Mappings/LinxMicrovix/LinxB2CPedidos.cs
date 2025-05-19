using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxB2CPedidosMap : IEntityTypeConfiguration<LinxB2CPedidos>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxB2CPedidos> builder)
        {
            builder.ToTable("LinxB2CPedidos");

            builder.HasKey(e => new { e.id_pedido, e.cod_cliente_erp, e.cod_cliente_b2c, e.empresa, e.order_id });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_pedido)
                .HasColumnType("int");

            builder.Property(e => e.dt_pedido)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cod_cliente_erp)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente_b2c)
                .HasColumnType("int");

            builder.Property(e => e.vl_frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.forma_pgto)
                .HasColumnType("int");

            builder.Property(e => e.plano_pagamento)
                .HasColumnType("int");

            builder.Property(e => e.anotacao)
                .HasColumnType("varchar(400)");

            builder.Property(e => e.taxa_impressao)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.finalizado)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.valor_frete_gratis)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.tipo_frete)
                .HasColumnType("int");

            builder.Property(e => e.id_status)
                .HasColumnType("int");

            builder.Property(e => e.cod_transportador)
                .HasColumnType("int");

            builder.Property(e => e.tipo_cobranca_frete)
                .HasColumnType("int");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.id_tabela_preco)
                .HasColumnType("int");

            builder.Property(e => e.valor_credito)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cod_vendedor)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.dt_insert)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.dt_disponivel_faturamento)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.mensagem_falha_faturamento)
                .HasProviderColumnType(LogicalColumnType.Varchar_Max);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_tipo_b2c)
                .HasColumnType("int");

            builder.Property(e => e.ecommerce_origem)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.marketplace_loja)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.order_id)
                .HasColumnType("varchar(40)");
        }
    }
}
