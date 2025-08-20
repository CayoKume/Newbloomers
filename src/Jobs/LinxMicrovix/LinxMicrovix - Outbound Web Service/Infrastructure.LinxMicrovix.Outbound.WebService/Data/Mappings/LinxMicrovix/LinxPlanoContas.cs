using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPlanoContasMap : IEntityTypeConfiguration<LinxPlanoContas>
    {
        public void Configure(EntityTypeBuilder<LinxPlanoContas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxPlanoContas));

            builder.ToTable("LinxPlanoContas");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_conta);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.cnpj)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_conta)
                .HasColumnType("int");

            builder.Property(e => e.nome_conta)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.sintetica)
                .HasColumnType("char(1)");

            builder.Property(e => e.indice)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.ativa)
                .HasColumnType("char(1)");

            builder.Property(e => e.fluxo_caixa)
                .HasColumnType("char(1)");

            builder.Property(e => e.conta_contabil)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.id_natureza_conta)
                .HasColumnType("int");

            builder.Property(e => e.conta_bancaria)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
