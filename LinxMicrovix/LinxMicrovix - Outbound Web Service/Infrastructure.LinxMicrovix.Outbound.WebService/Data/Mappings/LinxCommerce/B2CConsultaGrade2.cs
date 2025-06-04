using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaGrade2Map : IEntityTypeConfiguration<B2CConsultaGrade2>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaGrade2> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaGrade2));

            builder.ToTable("B2CConsultaGrade2");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.codigo_grade2);
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

            builder.Property(e => e.codigo_grade2)
                .HasColumnType("int");

            builder.Property(e => e.nome_grade2)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
