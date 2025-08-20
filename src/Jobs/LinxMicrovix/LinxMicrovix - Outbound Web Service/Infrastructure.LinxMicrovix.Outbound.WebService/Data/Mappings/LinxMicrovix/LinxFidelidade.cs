using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxFidelidadeMap : IEntityTypeConfiguration<LinxFidelidade>
    {
        public void Configure(EntityTypeBuilder<LinxFidelidade> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxFidelidade));

            builder.ToTable("LinxFidelidade");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_fidelidade_parceiro_log);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_fidelidade_parceiro_log)
                .HasColumnType("int");

            builder.Property(e => e.data_transacao)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.operacao)
                .HasColumnType("int");

            builder.Property(e => e.aprovado_barramento)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.valor_monetario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.numero_cartao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.identificador_movimento)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
