using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxOrcamentoComponenteFormula
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? id_orcamento_componente_formula { get; private set; }

        public Int32? documento { get; private set; }

        public Int64? codigo_produto { get; private set; }

        [LengthValidation(length: 10, propertyName: "codigo_componente")]
        public string? codigo_componente { get; private set; }

        [LengthValidation(length: 50, propertyName: "descricao_componente")]
        public string? descricao_componente { get; private set; }

        [LengthValidation(length: 5, propertyName: "unidade")]
        public string? unidade { get; private set; }

        public decimal? quantidade { get; private set; }

        public decimal? valor_componente { get; private set; }

        [LengthValidation(length: 30, propertyName: "lote_componente")]
        public string? lote_componente { get; private set; }

        public DateTime? data_validade_lote { get; private set; }

        [LengthValidation(length: 50, propertyName: "codigo_ws")]
        public string? codigo_ws { get; private set; }

        public Int32? portal { get; private set; }

        public Int64? timestamp { get; private set; }

    }

    public class LinxOrcamentoComponenteFormulaTrustedMap : IEntityTypeConfiguration<LinxOrcamentoComponenteFormula>
    {
        public void Configure(EntityTypeBuilder<LinxOrcamentoComponenteFormula> builder)
        {
            builder.ToTable("LinxOrcamentoComponenteFormula", "linx_microvix_erp");

            builder.HasKey(e => e.id_orcamento_componente_formula);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

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
                .HasColumnType("int");

            builder.Property(e => e.codigo_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxOrcamentoComponenteFormulaRawMap : IEntityTypeConfiguration<LinxOrcamentoComponenteFormula>
    {
        public void Configure(EntityTypeBuilder<LinxOrcamentoComponenteFormula> builder)
        {
            builder.ToTable("LinxOrcamentoComponenteFormula", "untreated");

            builder.HasKey(e => e.id_orcamento_componente_formula);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

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
                .HasColumnType("int");

            builder.Property(e => e.codigo_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
