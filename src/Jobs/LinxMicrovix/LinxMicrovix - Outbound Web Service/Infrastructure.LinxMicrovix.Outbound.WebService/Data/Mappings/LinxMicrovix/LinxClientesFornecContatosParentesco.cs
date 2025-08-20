using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxClientesFornecContatosParentescoMap : IEntityTypeConfiguration<LinxClientesFornecContatosParentesco>
    {
        public void Configure(EntityTypeBuilder<LinxClientesFornecContatosParentesco> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxClientesFornecContatosParentesco));

            builder.ToTable("LinxClientesFornecContatosParentesco");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_parentesco);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_parentesco)
                .HasColumnType("int");

            builder.Property(e => e.descricao_parentesco)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
