using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.LinxMicrovix.Outbound.WebService.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxAcoesPromocionaisTrustedMap : IEntityTypeConfiguration<LinxAcoesPromocionais>
    {
        public void Configure(EntityTypeBuilder<LinxAcoesPromocionais> builder)
        {
            builder
                .ToTable("LinxAcoesPromocionais", "linx_microvix_erp")
                .HasKey(x => x.id_acoes_promocionais);

            builder
                .Property(x => x.id_acoes_promocionais)
                .HasColumnType("int");

            builder
                .Property(x => x.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder
                .Property(x => x.portal)
                .HasColumnType("int");

            builder
                .Property(x => x.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder
                .Property(x => x.descricao)
                .HasColumnType("varchar(100)");

            builder
                .Property(x => x.vigencia_inicio)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder
                .Property(x => x.vigencia_fim)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder
                .Property(x => x.observacao)
                .HasColumnType("varchar(max)");

            builder
                .Property(x => x.ativa)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder
                .Property(x => x.excluida)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder
                .Property(x => x.integrada)
                .HasProviderColumnType(LogicalColumnType.Bool); 

            builder
                .Property(x => x.qtde_integrada)
                .HasColumnType("int");

            builder
                .Property(x => x.valor_pago_franqueadora)
                .HasColumnType("decimal(10,2)");
        }
    }

    public class LinxAcoesPromocionaisRawMap : IEntityTypeConfiguration<LinxAcoesPromocionais>
    {
        public void Configure(EntityTypeBuilder<LinxAcoesPromocionais> builder)
        {
            builder
                .ToTable("LinxAcoesPromocionais", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.id_acoes_promocionais)
                .HasColumnType("int");

            builder
                .Property(x => x.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder
                .Property(x => x.portal)
                .HasColumnType("int");

            builder
                .Property(x => x.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder
                .Property(x => x.descricao)
                .HasColumnType("varchar(100)");

            builder
                .Property(x => x.vigencia_inicio)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder
                .Property(x => x.vigencia_fim)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder
                .Property(x => x.observacao)
                .HasColumnType("varchar(max)");

            builder
                .Property(x => x.ativa)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder
                .Property(x => x.excluida)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder
                .Property(x => x.integrada)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder
                .Property(x => x.qtde_integrada)
                .HasColumnType("int");

            builder
                .Property(x => x.valor_pago_franqueadora)
                .HasColumnType("decimal(10,2)");
        }
    }
}
