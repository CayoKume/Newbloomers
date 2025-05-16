using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaEspessurasMap : IEntityTypeConfiguration<B2CConsultaEspessuras>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaEspessuras> builder)
        {
            builder.ToTable("B2CConsultaEspessuras", "linx_microvix_commerce");

            builder.HasKey(e => e.codigo_espessura);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_espessura)
                .HasColumnType("int");

            builder.Property(e => e.nome_espessura)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
