using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaFormasPagamentoMap : IEntityTypeConfiguration<B2CConsultaFormasPagamento>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaFormasPagamento> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaFormasPagamento));

            builder.ToTable("B2CConsultaFormasPagamento");

            if (schema == "linx_microvix_commerce")
                builder.HasKey(e => e.cod_forma_pgto);
            
            
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.cod_forma_pgto)
                .HasColumnType("int");

            builder.Property(e => e.forma_pgto)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
