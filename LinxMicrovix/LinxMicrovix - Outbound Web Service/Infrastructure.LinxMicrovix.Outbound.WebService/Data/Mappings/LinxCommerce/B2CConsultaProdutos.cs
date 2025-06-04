using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosMap : IEntityTypeConfiguration<B2CConsultaProdutos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutos));

            builder.ToTable("B2CConsultaProdutos");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.codigoproduto);
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

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.referencia)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.codauxiliar1)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.descricao_basica)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.nome_produto)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.peso_liquido)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.codigo_setor)
                .HasColumnType("int");

            builder.Property(e => e.codigo_linha)
                .HasColumnType("int");

            builder.Property(e => e.codigo_marca)
                .HasColumnType("int");

            builder.Property(e => e.codigo_colecao)
                .HasColumnType("int");

            builder.Property(e => e.codigo_espessura)
                .HasColumnType("int");

            builder.Property(e => e.codigo_grade1)
                .HasColumnType("int");

            builder.Property(e => e.codigo_grade2)
                .HasColumnType("int");

            builder.Property(e => e.unidade)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.codigo_classificacao)
                .HasColumnType("int");

            builder.Property(e => e.dt_cadastro)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.observacao)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.cod_fornecedor)
                .HasColumnType("int");

            builder.Property(e => e.dt_update)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.altura_para_frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.largura_para_frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.comprimento_para_frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.peso_bruto)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao_completa_commerce)
                .HasColumnType("varchar(8000)");

            builder.Property(e => e.canais_ecommerce_publicados)
                .HasProviderColumnType(EnumTableColumnType.TinyInt);

            builder.Property(e => e.inicio_publicacao_produto)
                .HasColumnType("date");

            builder.Property(e => e.fim_publicacao_produto)
                .HasColumnType("date");

            builder.Property(e => e.codigo_integracao_oms)
                .HasColumnType("varchar(50)");
        }
    }
}
