using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxRemessasIdentificadoresMap : IEntityTypeConfiguration<LinxRemessasIdentificadores>
    {
        public void Configure(EntityTypeBuilder<LinxRemessasIdentificadores> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxRemessasIdentificadores));

            builder.ToTable("LinxRemessasIdentificadores");

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

            builder.Property(e => e.identificador_venda)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.identificador_remessa)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.id_remessas)
                .HasColumnType("int");

            builder.Property(e => e.id_remessas_acertos)
                .HasColumnType("int");

            builder.Property(e => e.transacao_acerto)
                .HasColumnType("int");

            builder.Property(e => e.qtde_total_acerto)
                .HasColumnType("int");

            builder.Property(e => e.identificador_devolucao)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.transacao_remessa)
                .HasColumnType("int");

            builder.Property(e => e.id_remessa_operacoes)
                .HasColumnType("int");
        }
    }
}
