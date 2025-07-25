using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxClientesFornecCamposAdicionaisMap : IEntityTypeConfiguration<LinxClientesFornecCamposAdicionais>
    {
        public void Configure(EntityTypeBuilder<LinxClientesFornecCamposAdicionais> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxClientesFornecCamposAdicionais));

            builder.ToTable("LinxClientesFornecCamposAdicionais");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new { e.cod_cliente });
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

            builder.Property(e => e.campo)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.valor)
                .HasColumnType("varchar(100)");
        }
    }
}
