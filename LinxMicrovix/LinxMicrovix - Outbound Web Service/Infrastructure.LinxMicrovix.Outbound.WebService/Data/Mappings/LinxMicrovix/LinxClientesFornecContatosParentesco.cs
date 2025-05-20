using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxClientesFornecContatosParentescoMap : IEntityTypeConfiguration<LinxClientesFornecContatosParentesco>
    {
        public void Configure(EntityTypeBuilder<LinxClientesFornecContatosParentesco> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxClientesFornecContatosParentesco));

            builder.ToTable("LinxClientesFornecContatosParentesco");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_parentesco);
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
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_parentesco)
                .HasColumnType("int");

            builder.Property(e => e.descricao_parentesco)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
