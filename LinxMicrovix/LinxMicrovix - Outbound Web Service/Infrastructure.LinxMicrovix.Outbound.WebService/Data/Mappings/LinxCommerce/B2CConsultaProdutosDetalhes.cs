using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesMap : IEntityTypeConfiguration<B2CConsultaProdutosDetalhes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDetalhes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosDetalhes));

            builder.ToTable("B2CConsultaProdutosDetalhes");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.id_prod_det);
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

            builder.Property(e => e.id_prod_det)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.saldo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.controla_lote)
                .HasProviderColumnType(EnumTableColumnType.Bool);

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
