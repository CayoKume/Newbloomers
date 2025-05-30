using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCampanhasMap : IEntityTypeConfiguration<B2CConsultaProdutosCampanhas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCampanhas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosCampanhas));

            builder.ToTable("B2CConsultaProdutosCampanhas");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.codigo_campanha);
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
