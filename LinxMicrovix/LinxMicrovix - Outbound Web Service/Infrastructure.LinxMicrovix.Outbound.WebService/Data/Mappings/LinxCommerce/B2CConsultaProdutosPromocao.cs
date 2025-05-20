using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosPromocaoMap : IEntityTypeConfiguration<B2CConsultaProdutosPromocao>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosPromocao> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosPromocao));

            builder.ToTable("B2CConsultaProdutosPromocao");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.codigo_promocao);
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
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_promocao)
                .HasColumnType("bigint");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.preco)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.data_inicio)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.data_termino)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.data_cadastro)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.ativa)
                .HasColumnType("char(1)");

            builder.Property(e => e.codigo_campanha)
                .HasColumnType("int");

            builder.Property(e => e.promocao_opcional)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.referencia)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
