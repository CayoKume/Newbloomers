using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosInformacoesMap : IEntityTypeConfiguration<LinxProdutosInformacoes>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosInformacoes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxProdutosInformacoes));

            builder.ToTable("LinxProdutosInformacoes");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.codigoproduto);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.informacoes_produto)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);
        }
    }
}
