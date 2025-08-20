using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosImagensMap : IEntityTypeConfiguration<B2CConsultaProdutosImagens>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosImagens> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosImagens));

            builder.ToTable("B2CConsultaProdutosImagens");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.id_imagem_produto);
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

            builder.Property(e => e.id_imagem_produto)
                .HasColumnType("int");

            builder.Property(e => e.id_imagem)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
