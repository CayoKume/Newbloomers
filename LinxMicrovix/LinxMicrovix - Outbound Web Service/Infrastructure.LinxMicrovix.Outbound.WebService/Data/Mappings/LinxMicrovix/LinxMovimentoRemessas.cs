using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoRemessasMap : IEntityTypeConfiguration<LinxMovimentoRemessas>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoRemessas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoRemessas));

            builder.ToTable("LinxMovimentoRemessas");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_remessas);
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

            builder.Property(e => e.id_remessas)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.id_tipo)
                .HasColumnType("int");

            builder.Property(e => e.identificador_remessa)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.status)
                .HasColumnType("int");

            builder.Property(e => e.status_descricao)
                .HasColumnType("varchar(35)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
