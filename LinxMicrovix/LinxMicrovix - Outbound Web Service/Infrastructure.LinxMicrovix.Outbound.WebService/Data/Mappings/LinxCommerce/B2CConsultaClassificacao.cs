using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaClassificacaoMap : IEntityTypeConfiguration<B2CConsultaClassificacao>
    {
        

        

        public void Configure(EntityTypeBuilder<B2CConsultaClassificacao> builder)
        {
            builder.ToTable("B2CConsultaClassificacao");

            builder.HasKey(e => e.codigo_classificacao);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_classificacao)
                .HasColumnType("int");

            builder.Property(e => e.nome_classificacao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}