using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesDepositosMap : IEntityTypeConfiguration<B2CConsultaProdutosDetalhesDepositos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDetalhesDepositos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosDetalhesDepositos));

            builder.ToTable("B2CConsultaProdutosDetalhesDepositos");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.id_deposito);
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

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.id_deposito)
                .HasColumnType("int");

            builder.Property(e => e.saldo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.deposito)
                .HasColumnType("int");

            builder.Property(e => e.tempo_preparacao_estoque)
                .HasColumnType("smallint");
        }
    }
}
