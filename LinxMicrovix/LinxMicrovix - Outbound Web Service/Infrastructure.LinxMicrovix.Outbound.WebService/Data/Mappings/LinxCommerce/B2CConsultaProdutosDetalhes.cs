using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesMap : IEntityTypeConfiguration<B2CConsultaProdutosDetalhes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDetalhes> builder)
        {
            builder.ToTable("B2CConsultaProdutosDetalhes", "linx_microvix_commerce");

            builder.HasKey(e => e.id_prod_det);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_prod_det)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.saldo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.controla_lote)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.nomeproduto_alternativo)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.referencia)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.localizacao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.tempo_preparacao_estoque)
                .HasColumnType("smallint");
        }
    }
}
