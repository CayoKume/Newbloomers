using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosDetalhesDepositosMap : IEntityTypeConfiguration<LinxProdutosDetalhesDepositos>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosDetalhesDepositos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxProdutosDetalhesDepositos));

            builder.ToTable("LinxProdutosDetalhesDepositos");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.cod_produto);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.cod_produto)
                .HasColumnType("bigint");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.cod_deposito)
                .HasColumnType("int");

            builder.Property(e => e.saldo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
