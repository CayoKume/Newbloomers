using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxClientesFornecClassesMap : IEntityTypeConfiguration<LinxClientesFornecClasses>
    {
        public void Configure(EntityTypeBuilder<LinxClientesFornecClasses> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxClientesFornecClasses));

            builder.ToTable("LinxClientesFornecClasses");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new { e.cod_cliente, e.cod_classe });
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

            builder.Property(e => e.cod_cliente)
                .HasColumnType("int");

            builder.Property(e => e.cod_classe)
                .HasColumnType("int");

            builder.Property(e => e.nome_classe)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
