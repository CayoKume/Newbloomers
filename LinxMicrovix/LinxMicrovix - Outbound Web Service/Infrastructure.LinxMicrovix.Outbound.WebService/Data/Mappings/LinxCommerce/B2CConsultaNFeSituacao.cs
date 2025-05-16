using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaNFeSituacaoMap : IEntityTypeConfiguration<B2CConsultaNFeSituacao>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaNFeSituacao> builder)
        {
            builder.ToTable("B2CConsultaNFeSituacao", "linx_microvix_commerce");

            builder.HasKey(e => e.id_nfe_situacao);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_nfe_situacao)
                .HasProviderColumnType(LogicalColumnType.TinyInt);

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
