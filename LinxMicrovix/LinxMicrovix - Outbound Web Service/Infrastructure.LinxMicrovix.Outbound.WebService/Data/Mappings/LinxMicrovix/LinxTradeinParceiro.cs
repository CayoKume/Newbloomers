using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxTradeinParceiroMap : IEntityTypeConfiguration<LinxTradeinParceiro>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxTradeinParceiro> builder)
        {
            builder.ToTable("LinxTradeinParceiro");

            builder.HasKey(e => e.id_tradein_parceiro);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_tradein_parceiro)
                .HasColumnType("int");

            builder.Property(e => e.nome_parceiro)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
