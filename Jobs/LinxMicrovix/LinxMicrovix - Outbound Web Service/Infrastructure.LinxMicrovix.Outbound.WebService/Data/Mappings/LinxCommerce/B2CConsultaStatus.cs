using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaStatusMap : IEntityTypeConfiguration<B2CConsultaStatus>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaStatus> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaStatus));

            builder.ToTable("B2CConsultaStatus");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.id_status);
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

            builder.Property(e => e.id_status)
                .HasColumnType("int");

            builder.Property(e => e.descricao_status)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
