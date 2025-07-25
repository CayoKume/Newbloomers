using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosPromocoesMap : IEntityTypeConfiguration<LinxProdutosPromocoes>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosPromocoes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxProdutosPromocoes));

            builder.ToTable("LinxProdutosPromocoes");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new
                {
                    e.cnpj_emp,
                    e.cod_produto,
                    e.data_cadastro_promocao,
                    e.id_campanha
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
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.cod_produto)
                .HasColumnType("bigint");

            builder.Property(e => e.preco_promocao)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.data_inicio_promocao)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.data_termino_promocao)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.data_cadastro_promocao)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.promocao_ativa)
                .HasColumnType("char(1)");

            builder.Property(e => e.id_campanha)
                .HasColumnType("bigint");

            builder.Property(e => e.nome_campanha)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.promocao_opcional)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.custo_total_campanha)
                .HasColumnType("decimal(10,2)");
        }
    }
}
