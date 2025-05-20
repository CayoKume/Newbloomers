using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPedidosCompraMap : IEntityTypeConfiguration<LinxPedidosCompra>
    {
        public void Configure(EntityTypeBuilder<LinxPedidosCompra> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxPedidosCompra));

            builder.ToTable("LinxPedidosCompra");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new
                {
                    e.cnpj_emp,
                    e.cod_pedido,
                    e.codigo_fornecedor,
                    e.cod_produto
                });
                builder.Ignore(x => x.id);
            }
            else
            {
                builder.HasKey(x => x.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.cod_pedido)
                .HasColumnType("int");

            builder.Property(e => e.data_pedido)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.usuario)
                .HasColumnType("int");

            builder.Property(e => e.codigo_fornecedor)
                .HasColumnType("int");

            builder.Property(e => e.cod_produto)
                .HasColumnType("bigint");

            builder.Property(e => e.quantidade)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_unitario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cod_comprador)
                .HasColumnType("int");

            builder.Property(e => e.valor_frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_total)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cod_plano_pagamento)
                .HasColumnType("int");

            builder.Property(e => e.plano_pagamento)
                .HasColumnType("varchar(35)");

            builder.Property(e => e.obs)
                .HasProviderColumnType(LogicalColumnType.Varchar_Max);

            builder.Property(e => e.aprovado)
                .HasColumnType("char(1)");

            builder.Property(e => e.cancelado)
                .HasColumnType("char(1)");

            builder.Property(e => e.encerrado)
                .HasColumnType("char(1)");

            builder.Property(e => e.data_aprovacao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.numero_ped_fornec)
                .HasColumnType("varchar(15)");

            builder.Property(e => e.tipo_frete)
                .HasColumnType("char(1)");

            builder.Property(e => e.natureza_operacao)
                .HasColumnType("varchar(73)");

            builder.Property(e => e.previsao_entrega)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.numero_projeto_officina)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.status_pedido)
                .HasColumnType("char(1)");

            builder.Property(e => e.qtde_entregue)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.descricao_frete)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.integrado_linx)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.nf_gerada)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.nf_origem_ws)
                .HasColumnType("varchar(30)");
        }
    }
}
