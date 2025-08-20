using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoCamposAdicionaisMap : IEntityTypeConfiguration<LinxMovimentoCamposAdicionais>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoCamposAdicionais> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoCamposAdicionais));

            builder.ToTable("LinxMovimentoCamposAdicionais");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_ordservprod);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_ordservprod)
                .HasColumnType("int");

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.paciente)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.codigo_gerencial)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
