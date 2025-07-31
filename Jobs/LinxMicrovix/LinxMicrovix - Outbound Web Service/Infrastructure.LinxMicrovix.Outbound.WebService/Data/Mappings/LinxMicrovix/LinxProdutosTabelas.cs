using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosTabelasMap : IEntityTypeConfiguration<LinxProdutosTabelas>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosTabelas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxProdutosTabelas));

            builder.ToTable("LinxProdutosTabelas");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new { e.id_tabela, e.cnpj_emp, e.tipo_tabela });
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

            builder.Property(e => e.id_tabela)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.nome_tabela)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativa)
                .HasColumnType("char(1)");

            builder.Property(e => e.timestamp)
                .HasColumnType("int");

            builder.Property(e => e.tipo_tabela)
                .HasColumnType("char(1)");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");
        }
    }
}
