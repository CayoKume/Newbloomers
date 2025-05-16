using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosDepositosMap : IEntityTypeConfiguration<B2CConsultaProdutosDepositos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDepositos> builder)
        {
            builder.ToTable("B2CConsultaProdutosDepositos", "linx_microvix_commerce");

            builder.HasKey(e => e.id_deposito);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_deposito)
                .HasColumnType("int");

            builder.Property(e => e.nome_deposito)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.disponivel)
                .HasColumnType("char(1)");

            builder.Property(e => e.disponivel_transferencia)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.disponivel_franquias)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
