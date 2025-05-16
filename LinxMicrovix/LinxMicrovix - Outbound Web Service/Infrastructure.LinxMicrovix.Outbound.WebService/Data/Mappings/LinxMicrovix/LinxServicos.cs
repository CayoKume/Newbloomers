using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxServicosMap : IEntityTypeConfiguration<LinxServicos>
    {
        public void Configure(EntityTypeBuilder<LinxServicos> builder)
        {
            builder.ToTable("LinxServicos", "linx_microvix_erp");

            builder.HasKey(e => e.cod_servico);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_setor)
                .HasColumnType("int");

            builder.Property(e => e.cod_servico)
                .HasColumnType("bigint");

            builder.Property(e => e.nome)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.desc_setor)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.id_linha)
                .HasColumnType("int");

            builder.Property(e => e.desc_linha)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.id_marca)
                .HasColumnType("int");

            builder.Property(e => e.desc_marca)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.dt_update)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.operacao_servico)
                .HasColumnType("char(1)");

            builder.Property(e => e.servico_km)
                .HasColumnType("char(1)");

            builder.Property(e => e.desativado)
                .HasColumnType("char(1)");

            builder.Property(e => e.cod_lc11603)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.codigo_nbs)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.dt_inclusao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }

    public class LinxServicosRawMap : IEntityTypeConfiguration<LinxServicos>
    {
        public void Configure(EntityTypeBuilder<LinxServicos> builder)
        {
            builder.ToTable("LinxServicos", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_setor)
                .HasColumnType("int");

            builder.Property(e => e.cod_servico)
                .HasColumnType("bigint");

            builder.Property(e => e.nome)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.desc_setor)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.id_linha)
                .HasColumnType("int");

            builder.Property(e => e.desc_linha)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.id_marca)
                .HasColumnType("int");

            builder.Property(e => e.desc_marca)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.dt_update)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.operacao_servico)
                .HasColumnType("char(1)");

            builder.Property(e => e.servico_km)
                .HasColumnType("char(1)");

            builder.Property(e => e.desativado)
                .HasColumnType("char(1)");

            builder.Property(e => e.cod_lc11603)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.codigo_nbs)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.dt_inclusao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
