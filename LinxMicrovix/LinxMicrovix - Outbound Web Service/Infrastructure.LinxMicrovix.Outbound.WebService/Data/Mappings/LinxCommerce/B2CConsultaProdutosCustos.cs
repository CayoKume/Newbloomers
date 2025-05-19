using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCustosMap : IEntityTypeConfiguration<B2CConsultaProdutosCustos>
    {
        

        

        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCustos> builder)
        {
            builder.ToTable("B2CConsultaProdutosCustos");

            builder.HasKey(e => new { e.id_produtos_custos, e.codigoproduto });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_produtos_custos)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.custoicms1)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.ipi1)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.markup)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.customedio)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.frete1)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.precisao)
                .HasColumnType("int");

            builder.Property(e => e.precominimo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.dt_update)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.custoliquido)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.precovenda)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.custototal)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.precocompra)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
