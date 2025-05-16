using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxSangriaSuprimentosTrustedMap : IEntityTypeConfiguration<LinxSangriaSuprimentos>
    {
        public void Configure(EntityTypeBuilder<LinxSangriaSuprimentos> builder)
        {
            builder.ToTable("LinxSangriaSuprimentos", "linx_microvix_erp");

            builder.HasKey(e => e.id_sangria_suprimentos);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.usuario)
                .HasColumnType("int");

            builder.Property(e => e.data)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.obs)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.cancelado)
                .HasColumnType("char(1)");

            builder.Property(e => e.conferido)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.cod_historico)
                .HasColumnType("bigint");

            builder.Property(e => e.desc_historico)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.id_sangria_suprimentos)
                .HasColumnType("int");
        }
    }

    public class LinxSangriaSuprimentosRawMap : IEntityTypeConfiguration<LinxSangriaSuprimentos>
    {
        public void Configure(EntityTypeBuilder<LinxSangriaSuprimentos> builder)
        {
            builder.ToTable("LinxSangriaSuprimentos", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.usuario)
                .HasColumnType("int");

            builder.Property(e => e.data)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.obs)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.cancelado)
                .HasColumnType("char(1)");

            builder.Property(e => e.conferido)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.cod_historico)
                .HasColumnType("bigint");

            builder.Property(e => e.desc_historico)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.id_sangria_suprimentos)
                .HasColumnType("int");
        }
    }
}
