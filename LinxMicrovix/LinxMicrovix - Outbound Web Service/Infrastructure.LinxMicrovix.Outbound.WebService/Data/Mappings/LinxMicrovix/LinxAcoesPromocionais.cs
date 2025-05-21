using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.IntegrationsCore.Entities.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxAcoesPromocionaisMap : IEntityTypeConfiguration<LinxAcoesPromocionais>
    {
        public void Configure(EntityTypeBuilder<LinxAcoesPromocionais> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxAcoesPromocionais));

            builder.ToTable("LinxAcoesPromocionais");

            if(schema == "linx_microvix_erp")
            {
                builder.HasKey(x => x.id_acoes_promocionais);
                builder.Ignore(e => e.id);
            }
            else
            {
                builder.HasKey(x => x.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }
            
            builder
                .Property(x => x.id_acoes_promocionais)
                .HasColumnType("int");

            builder
                .Property(x => x.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

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
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.vigencia_fim)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.observacao)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder
                .Property(x => x.ativa)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.excluida)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.integrada)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.qtde_integrada)
                .HasColumnType("int");

            builder
                .Property(x => x.valor_pago_franqueadora)
                .HasColumnType("decimal(10,2)");
        }
    }
}
