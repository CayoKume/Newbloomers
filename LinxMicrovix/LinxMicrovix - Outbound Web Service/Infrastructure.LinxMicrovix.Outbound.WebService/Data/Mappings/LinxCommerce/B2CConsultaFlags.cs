using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaFlagsMap : IEntityTypeConfiguration<B2CConsultaFlags>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaFlags> builder)
        {
            builder.ToTable("B2CConsultaFlags", "linx_microvix_commerce");

            builder.HasKey(e => e.id_b2c_flags);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_b2c_flags)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(300)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
