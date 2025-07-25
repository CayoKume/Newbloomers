using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosDepositosMap : IEntityTypeConfiguration<LinxProdutosDepositos>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosDepositos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxProdutosDepositos));

            builder.ToTable("LinxProdutosDepositos");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.cod_deposito);
                builder.Ignore(x => x.id);
            }
            else
            {
                builder.HasKey(x => x.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cod_deposito)
                .HasColumnType("int");

            builder.Property(e => e.nome_deposito)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.disponivel)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.disponivel_transferencia)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
