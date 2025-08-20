using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Core.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxOrcamentoComponenteFormulaMap : IEntityTypeConfiguration<LinxOrcamentoComponenteFormula>
    {
        public void Configure(EntityTypeBuilder<LinxOrcamentoComponenteFormula> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxOrcamentoComponenteFormula));

            builder.ToTable("LinxOrcamentoComponenteFormula");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_orcamento_componente_formula);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_orcamento_componente_formula)
                .HasColumnType("int");

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.codigo_produto)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_componente)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.descricao_componente)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.unidade)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.quantidade)
                .HasColumnType("int");

            builder.Property(e => e.valor_componente)
                .HasColumnType("int");

            builder.Property(e => e.lote_componente)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.data_validade_lote)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.codigo_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
