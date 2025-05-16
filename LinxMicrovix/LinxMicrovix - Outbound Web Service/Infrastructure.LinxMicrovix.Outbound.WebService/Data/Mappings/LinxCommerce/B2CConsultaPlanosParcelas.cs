using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPlanosParcelasMap : IEntityTypeConfiguration<B2CConsultaPlanosParcelas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPlanosParcelas> builder)
        {
            builder.ToTable("B2CConsultaPlanosParcelas", "linx_microvix_commerce");

            builder.HasKey(e => e.plano);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.plano)
                .HasColumnType("int");

            builder.Property(e => e.ordem_parcela)
                .HasColumnType("int");

            builder.Property(e => e.prazo_parc)
                .HasColumnType("int");

            builder.Property(e => e.id_planos_parcelas)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
