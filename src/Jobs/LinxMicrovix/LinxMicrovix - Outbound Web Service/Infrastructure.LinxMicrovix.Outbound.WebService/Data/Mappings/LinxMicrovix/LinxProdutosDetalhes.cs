using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosDetalhesMap : IEntityTypeConfiguration<LinxProdutosDetalhes>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosDetalhes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxProdutosDetalhes));

            builder.ToTable("LinxProdutosDetalhes");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new { e.cnpj_emp, e.cod_produto });
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
                .HasColumnType("int");

            builder.Property(e => e.cod_barra)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.quantidade)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.preco_custo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.preco_venda)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.custo_medio)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_config_tributaria)
                .HasColumnType("int");

            builder.Property(e => e.desc_config_tributaria)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.despesas1)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.qtde_minima)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.qtde_maxima)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.ipi)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");
        }
    }
}
