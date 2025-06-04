using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoAcoesPromocionaisMap : IEntityTypeConfiguration<LinxMovimentoAcoesPromocionais>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoAcoesPromocionais> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoAcoesPromocionais));

            builder.ToTable("LinxMovimentoAcoesPromocionais");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.identificador);
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

            builder.Property(e => e.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.id_acoes_promocionais)
                .HasColumnType("int");

            builder.Property(e => e.desconto_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.quantidade)
                .HasColumnType("int");
        }
    }
}
