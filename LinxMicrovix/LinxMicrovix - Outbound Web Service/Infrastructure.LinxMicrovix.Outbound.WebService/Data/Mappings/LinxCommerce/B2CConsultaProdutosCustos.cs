using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCustosMap : IEntityTypeConfiguration<B2CConsultaProdutosCustos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCustos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosCustos));

            builder.ToTable("B2CConsultaProdutosCustos");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => new { e.id_produtos_custos, e.codigoproduto });
                builder.Ignore(e => e.id);
            }
            else
            {
                builder.HasKey(e => e.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }
            
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

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
                .HasProviderColumnType(EnumTableColumnType.DateTime);

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
