using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaClientesEstadoCivilMap : IEntityTypeConfiguration<B2CConsultaClientesEstadoCivil>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClientesEstadoCivil> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaClientesEstadoCivil));

            builder.ToTable("B2CConsultaClientesEstadoCivil");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.id_estado_civil);
                builder.Ignore(e => e.id);
            }
            else
            {
                builder.HasKey(e => e.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }
            
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_estado_civil)
                .HasColumnType("int");

            builder.Property(e => e.estado_civil)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
