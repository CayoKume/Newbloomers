using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoObservacoesMap : IEntityTypeConfiguration<LinxMovimentoObservacoes>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoObservacoes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoObservacoes));

            builder.ToTable("LinxMovimentoObservacoes");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_obs);
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

            builder.Property(e => e.id_obs)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.titulo_obs)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.descricao_obs)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
