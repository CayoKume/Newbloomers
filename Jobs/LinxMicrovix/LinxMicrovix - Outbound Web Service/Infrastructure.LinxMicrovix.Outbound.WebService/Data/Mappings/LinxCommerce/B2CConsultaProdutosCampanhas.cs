using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCampanhasMap : IEntityTypeConfiguration<B2CConsultaProdutosCampanhas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCampanhas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosCampanhas));

            builder.ToTable("B2CConsultaProdutosCampanhas");

            if (schema == "linx_microvix_commerce")
                builder.HasKey(e => e.codigo_campanha);
            
            
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.codigo_campanha)
                .HasColumnType("int");

            builder.Property(e => e.nome_campanha)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.vigencia_inicio)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.vigencia_fim)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.observacao)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.ativo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
