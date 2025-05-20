using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPedidosVendaMap : IEntityTypeConfiguration<LinxPedidosVenda>
    {
        public void Configure(EntityTypeBuilder<LinxPedidosVenda> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxPedidosVenda));

            builder.ToTable("LinxPedidosVenda");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new
                {
                    e.cnpj_emp,
                    e.cod_pedido,
                    e.codigo_cliente,
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

            builder.Property(e => e.data_lancamento)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.hora_lancamento)
                .HasColumnType("char(5)");

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.usuario)
                .HasColumnType("int");

            builder.Property(e => e.codigo_cliente)
                .HasColumnType("int");

            builder.Property(e => e.cod_produto)
                .HasColumnType("bigint");

            builder.Property(e => e.quantidade)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_unitario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cod_vendedor)
                .HasColumnType("int");

            builder.Property(e => e.valor_frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_total)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.desconto_item)
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

            builder.Property(e => e.data_aprovacao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.data_alteracao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.tipo_frete)
                .HasColumnType("int");

            builder.Property(e => e.natureza_operacao)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.tabela_preco)
                .HasColumnType("int");

            builder.Property(e => e.nome_tabela_preco)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.previsao_entrega)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.realizado_por)
                .HasColumnType("int");

            builder.Property(e => e.pontuacao_ser)
                .HasColumnType("int");

            builder.Property(e => e.venda_externa)
                .HasColumnType("char(1)");

            builder.Property(e => e.nf_gerada)
                .HasProviderColumnType(LogicalColumnType.Varchar_Max);

            builder.Property(e => e.status)
                .HasColumnType("char(1)");

            builder.Property(e => e.numero_projeto_officina)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.cod_natureza_operacao)
                .HasColumnType("char(10)");

            builder.Property(e => e.margem_contribuicao)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.doc_origem)
                .HasColumnType("int");

            builder.Property(e => e.posicao_item)
                .HasColumnType("int");

            builder.Property(e => e.orcamento_origem)
                .HasColumnType("int");

            builder.Property(e => e.transacao_origem)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.desconto)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.transacao_ws)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.transportador)
                .HasColumnType("bigint");

            builder.Property(e => e.deposito)
                .HasColumnType("int");
        }
    }
}
