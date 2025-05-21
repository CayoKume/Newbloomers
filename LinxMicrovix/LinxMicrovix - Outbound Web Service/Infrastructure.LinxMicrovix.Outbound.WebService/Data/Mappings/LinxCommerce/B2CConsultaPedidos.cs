using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPedidosMap : IEntityTypeConfiguration<B2CConsultaPedidos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaPedidos));

            builder.ToTable("B2CConsultaPedidos");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => new { e.id_pedido, e.cod_cliente_erp, e.cod_cliente_b2c, e.order_id });
                builder.Ignore(e => e.id);
            }
            else
            {
                builder.HasKey(e => e.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }
            
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_pedido)
                .HasColumnType("int");

            builder.Property(e => e.dt_pedido)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

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
                .HasProviderColumnType(EnumTableColumnType.Bool);

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
                .HasProviderColumnType(EnumTableColumnType.Bool);

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
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.dt_disponivel_faturamento)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.mensagem_falha_faturamento)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.id_tipo_b2c)
                .HasProviderColumnType(EnumTableColumnType.TinyInt);

            builder.Property(e => e.ecommerce_origem)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.order_id)
                .HasColumnType("varchar(40)");
        }
    }
}
