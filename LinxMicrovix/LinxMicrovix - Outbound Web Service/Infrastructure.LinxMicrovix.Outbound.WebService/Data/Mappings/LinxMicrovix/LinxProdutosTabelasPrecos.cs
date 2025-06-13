using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosTabelasPrecosMap : IEntityTypeConfiguration<LinxProdutosTabelasPrecos>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosTabelasPrecos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxProdutosTabelasPrecos));

            builder.ToTable("LinxProdutosTabelasPrecos");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new { e.cod_produto, e.cnpj_emp, e.id_tabela });
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

            builder.Property(e => e.cod_produto)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_tabela)
                .HasColumnType("int");

            builder.Property(e => e.precovenda)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
