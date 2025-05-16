using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoAcoesPromocionaisMap : IEntityTypeConfiguration<LinxMovimentoAcoesPromocionais>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoAcoesPromocionais> builder)
        {
            builder.ToTable("LinxMovimentoAcoesPromocionais", "linx_microvix_erp");

            builder.HasKey(e => e.identificador);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

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

    public class LinxMovimentoAcoesPromocionaisRawMap : IEntityTypeConfiguration<LinxMovimentoAcoesPromocionais>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoAcoesPromocionais> builder)
        {
            builder.ToTable("LinxMovimentoAcoesPromocionais", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

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
