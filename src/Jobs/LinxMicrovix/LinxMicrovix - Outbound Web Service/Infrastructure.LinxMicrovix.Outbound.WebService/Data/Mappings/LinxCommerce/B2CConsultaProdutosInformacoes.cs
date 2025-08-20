using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosInformacoesMap : IEntityTypeConfiguration<B2CConsultaProdutosInformacoes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosInformacoes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosInformacoes));

            builder.ToTable("B2CConsultaProdutosInformacoes");

            if (schema == "linx_microvix_commerce")
                builder.HasKey(e => e.id_produtos_informacoes);
            
            
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_produtos_informacoes)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.informacoes_produto)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
