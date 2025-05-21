using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxEnquadramentoIpiMap : IEntityTypeConfiguration<LinxEnquadramentoIpi>
    {
        public void Configure(EntityTypeBuilder<LinxEnquadramentoIpi> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxEnquadramentoIpi));

            builder.ToTable("LinxEnquadramentoIpi");

            if (schema == "linx_microvix_erp")
            { 
                builder.HasKey(e => e.id_enquadramento_ipi);
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

            builder.Property(e => e.id_enquadramento_ipi)
                .HasColumnType("int");

            builder.Property(e => e.codigo)
                .HasColumnType("varchar(3)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(600)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
