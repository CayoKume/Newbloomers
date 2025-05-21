using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCupomDescontoMap : IEntityTypeConfiguration<LinxCupomDesconto>
    {
        public void Configure(EntityTypeBuilder<LinxCupomDesconto> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxCupomDesconto));

            builder.ToTable("LinxCupomDesconto");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.empresa);
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

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.id_cupom_desconto)
                .HasColumnType("int");

            builder.Property(e => e.cupom)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.percentual_desconto)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.data_inicial_vigencia)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.data_final_vigencia)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.qtde_original)
                .HasColumnType("int");

            builder.Property(e => e.qtde_disponivel)
                .HasColumnType("int");

            builder.Property(e => e.cod_vendedor)
                .HasColumnType("int");

            builder.Property(e => e.disponivel)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
