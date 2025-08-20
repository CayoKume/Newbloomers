using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPlanosBandeirasMap : IEntityTypeConfiguration<LinxPlanosBandeiras>
    {
        public void Configure(EntityTypeBuilder<LinxPlanosBandeiras> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxPlanosBandeiras));

            builder.ToTable("LinxPlanosBandeiras");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.plano);
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

            builder.Property(e => e.plano)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.bandeira)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.tipo_bandeira)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.adquirente)
                .HasColumnType("int");

            builder.Property(e => e.nome_adquirente)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.codigo_bandeira_sitef)
                .HasColumnType("varchar(10)");
        }
    }
}
