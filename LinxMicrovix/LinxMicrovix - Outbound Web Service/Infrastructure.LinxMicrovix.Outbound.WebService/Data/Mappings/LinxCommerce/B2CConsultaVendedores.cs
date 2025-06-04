using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaVendedoresMap : IEntityTypeConfiguration<B2CConsultaVendedores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaVendedores> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaVendedores));

            builder.ToTable("B2CConsultaVendedores");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.cod_vendedor);
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

            builder.Property(e => e.cod_vendedor)
                .HasColumnType("int");

            builder.Property(e => e.nome_vendedor)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.comissao_produtos)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.comissao_servicos)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.tipo)
                .HasColumnType("char(1)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.comissionado)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
