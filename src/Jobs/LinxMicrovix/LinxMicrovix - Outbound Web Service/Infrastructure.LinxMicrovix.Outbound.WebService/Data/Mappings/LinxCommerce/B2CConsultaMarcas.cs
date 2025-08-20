using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaMarcasMap : IEntityTypeConfiguration<B2CConsultaMarcas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaMarcas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaMarcas));

            builder.ToTable("B2CConsultaMarcas");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.codigo_marca);
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

            builder.Property(e => e.codigo_marca)
                .HasColumnType("int");

            builder.Property(e => e.nome_marca)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.linhas)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
