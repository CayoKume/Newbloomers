using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaLinhasMap : IEntityTypeConfiguration<B2CConsultaLinhas>
    {
        

        

        public void Configure(EntityTypeBuilder<B2CConsultaLinhas> builder)
        {
            builder.ToTable("B2CConsultaLinhas");

            builder.HasKey(e => e.codigo_linha);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_linha)
                .HasColumnType("int");

            builder.Property(e => e.nome_linha)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.setores)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
