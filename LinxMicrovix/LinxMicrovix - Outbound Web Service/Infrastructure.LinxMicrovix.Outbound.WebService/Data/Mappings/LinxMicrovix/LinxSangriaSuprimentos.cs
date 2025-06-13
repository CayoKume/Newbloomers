using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxSangriaSuprimentosMap : IEntityTypeConfiguration<LinxSangriaSuprimentos>
    {
        public void Configure(EntityTypeBuilder<LinxSangriaSuprimentos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxSangriaSuprimentos));

            builder.ToTable("LinxSangriaSuprimentos");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_sangria_suprimentos);
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

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.usuario)
                .HasColumnType("int");

            builder.Property(e => e.data)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.obs)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.cancelado)
                .HasColumnType("char(1)");

            builder.Property(e => e.conferido)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.cod_historico)
                .HasColumnType("bigint");

            builder.Property(e => e.desc_historico)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.id_sangria_suprimentos)
                .HasColumnType("int");
        }
    }
}
