using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaLinhasMap : IEntityTypeConfiguration<B2CConsultaLinhas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaLinhas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaLinhas));

            builder.ToTable("B2CConsultaLinhas");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.codigo_linha);
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

            builder.Property(e => e.codigo_linha)
                .HasColumnType("int");

            builder.Property(e => e.nome_linha)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.setores)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
