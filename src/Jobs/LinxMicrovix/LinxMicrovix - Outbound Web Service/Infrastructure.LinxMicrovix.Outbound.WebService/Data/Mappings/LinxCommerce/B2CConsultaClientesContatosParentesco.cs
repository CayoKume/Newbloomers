using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaClientesContatosParentescoMap : IEntityTypeConfiguration<B2CConsultaClientesContatosParentesco>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClientesContatosParentesco> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaClientesContatosParentesco));

            builder.ToTable("B2CConsultaClientesContatosParentesco");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.id_parentesco);
                builder.Ignore(e => e.id);
            }
            else
            {
                builder.HasKey(e => e.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }
            
            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_parentesco)
                .HasColumnType("int");

            builder.Property(e => e.descricao_parentesco)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
