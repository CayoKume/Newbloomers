using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisNomesMap : IEntityTypeConfiguration<B2CConsultaProdutosCamposAdicionaisNomes>
    {
        

        

        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCamposAdicionaisNomes> builder)
        {
            builder.ToTable("B2CConsultaProdutosCamposAdicionaisNomes");

            builder.HasKey(e => e.id_campo);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_campo)
                .HasColumnType("int");

            builder.Property(e => e.ordem)
                .HasProviderColumnType(LogicalColumnType.TinyInt);

            builder.Property(e => e.legenda)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.tipo)
                .HasColumnType("char(1)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
