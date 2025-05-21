using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxTradeinParceiroMap : IEntityTypeConfiguration<LinxTradeinParceiro>
    {
        public void Configure(EntityTypeBuilder<LinxTradeinParceiro> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxTradeinParceiro));

            builder.ToTable("LinxTradeinParceiro");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_tradein_parceiro);
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

            builder.Property(e => e.id_tradein_parceiro)
                .HasColumnType("int");

            builder.Property(e => e.nome_parceiro)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
