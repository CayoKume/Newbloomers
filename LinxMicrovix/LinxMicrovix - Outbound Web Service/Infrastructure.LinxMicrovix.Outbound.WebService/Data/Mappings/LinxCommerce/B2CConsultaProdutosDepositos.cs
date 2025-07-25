using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.IntegrationsCore.Data.Extensions;

using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosDepositosMap : IEntityTypeConfiguration<B2CConsultaProdutosDepositos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDepositos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosDepositos));

            builder.ToTable("B2CConsultaProdutosDepositos");

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

            builder.Property(e => e.id_deposito)
                .HasColumnType("int");

            builder.Property(e => e.nome_deposito)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.disponivel)
                .HasColumnType("char(1)");

            builder.Property(e => e.disponivel_transferencia)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.disponivel_franquias)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
