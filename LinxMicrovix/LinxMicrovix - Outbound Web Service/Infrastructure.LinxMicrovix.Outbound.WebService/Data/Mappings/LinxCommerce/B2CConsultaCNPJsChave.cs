using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaCNPJsChaveMap : IEntityTypeConfiguration<B2CConsultaCNPJsChave>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaCNPJsChave> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaCNPJsChave));

            builder.ToTable("B2CConsultaCNPJsChave");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => new { e.cnpj, e.id_empresas_rede, e.empresa });
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

            builder.Property(e => e.cnpj)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.nome_empresa)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.id_empresas_rede)
                .HasColumnType("smallint");

            builder.Property(e => e.rede)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.nome_portal)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.classificacao_portal)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.b2c)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.oms)
                .HasProviderColumnType(EnumTableColumnType.Bool);
        }
    }
}
