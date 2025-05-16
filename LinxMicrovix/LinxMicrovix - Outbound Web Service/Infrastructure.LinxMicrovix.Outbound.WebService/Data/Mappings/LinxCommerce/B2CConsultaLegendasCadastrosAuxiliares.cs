using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaLegendasCadastrosAuxiliaresMap : IEntityTypeConfiguration<B2CConsultaLegendasCadastrosAuxiliares>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaLegendasCadastrosAuxiliares> builder)
        {
            builder.ToTable("B2CConsultaLegendasCadastrosAuxiliares", "linx_microvix_commerce");

            builder.HasKey(e => e.empresa);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.legenda_setor)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.legenda_linha)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.legenda_marca)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.legenda_colecao)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.legenda_grade1)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.legenda_grade2)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.legenda_espessura)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.legenda_classificacao)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
