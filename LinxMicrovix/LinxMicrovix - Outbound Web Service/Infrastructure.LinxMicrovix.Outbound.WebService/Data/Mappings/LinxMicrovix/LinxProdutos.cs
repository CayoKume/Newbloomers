using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosMap : IEntityTypeConfiguration<LinxProdutos>
    {
        public void Configure(EntityTypeBuilder<LinxProdutos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxProdutos));

            builder.ToTable("LinxProdutos");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.cod_produto);
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
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cod_produto)
                .HasColumnType("bigint");

            builder.Property(e => e.cod_barra)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.nome)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.ncm)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.cest)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.referencia)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.cod_auxiliar)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.unidade)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.desc_cor)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.desc_tamanho)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.desc_setor)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.desc_linha)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.desc_marca)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.desc_colecao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.dt_update)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.cod_fornecedor)
                .HasColumnType("int");

            builder.Property(e => e.desativado)
                .HasColumnType("char(10)");

            builder.Property(e => e.desc_espessura)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.id_espessura)
                .HasColumnType("int");

            builder.Property(e => e.desc_classificacao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.id_classificacao)
                .HasColumnType("int");

            builder.Property(e => e.origem_mercadoria)
                .HasColumnType("int");

            builder.Property(e => e.peso_liquido)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.peso_bruto)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_cor)
                .HasColumnType("int");

            builder.Property(e => e.id_tamanho)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.id_setor)
                .HasColumnType("int");

            builder.Property(e => e.id_linha)
                .HasColumnType("int");

            builder.Property(e => e.id_marca)
                .HasColumnType("int");

            builder.Property(e => e.id_colecao)
                .HasColumnType("int");

            builder.Property(e => e.dt_inclusao)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.fator_conversao)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.codigo_integracao_reshop)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.id_produtos_opticos_tipo)
                .HasColumnType("int");

            builder.Property(e => e.id_sped_tipo_item)
                .HasColumnType("int");

            builder.Property(e => e.componente)
                .HasColumnType("char(1)");

            builder.Property(e => e.altura_para_frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.largura_para_frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.comprimento_para_frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.loja_virtual)
                .HasColumnType("char(1)");

            builder.Property(e => e.cod_comprador)
                .HasColumnType("int");

            builder.Property(e => e.obrigatorio_identificacao_cliente)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.descricao_basica)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.curva)
                .HasColumnType("char(1)");
        }
    }
}
