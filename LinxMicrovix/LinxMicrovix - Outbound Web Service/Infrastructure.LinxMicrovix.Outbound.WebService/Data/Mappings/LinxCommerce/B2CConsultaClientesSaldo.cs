using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaClientesSaldoMap : IEntityTypeConfiguration<B2CConsultaClientesSaldo>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClientesSaldo> builder)
        {
            builder.ToTable("B2CConsultaClientesSaldo", "linx_microvix_commerce");

            builder.HasKey(e => new { e.cod_cliente_erp, e.empresa });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.saldo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cod_cliente_erp)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
