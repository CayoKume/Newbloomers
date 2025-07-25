using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxRespostaVendaMap : IEntityTypeConfiguration<LinxRespostaVenda>
    {
        public void Configure(EntityTypeBuilder<LinxRespostaVenda> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxRespostaVenda));

            builder.ToTable("LinxRespostaVenda");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_resposta_venda);
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

            builder.Property(e => e.id_resposta_venda)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao_resposta)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.id_pergunta_venda)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
