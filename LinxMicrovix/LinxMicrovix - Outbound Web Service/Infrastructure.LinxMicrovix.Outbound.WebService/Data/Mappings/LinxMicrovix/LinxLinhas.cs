using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxLinhasMap : IEntityTypeConfiguration<LinxLinhas>
    {
        public void Configure(EntityTypeBuilder<LinxLinhas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxLinhas));

            builder.ToTable("LinxLinhas");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_linha);
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

            builder.Property(e => e.id_linha)
                .HasColumnType("int");

            builder.Property(e => e.desc_linha)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.coeficiente_comissao)
                .HasColumnType("decimal(10,2)");
        }
    }
}
