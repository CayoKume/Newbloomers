using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoObservacoesMap : IEntityTypeConfiguration<LinxMovimentoObservacoes>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoObservacoes> builder)
        {
            builder.ToTable("LinxMovimentoObservacoes", "linx_microvix_erp");

            builder.HasKey(e => e.id_obs);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_obs)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.titulo_obs)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.descricao_obs)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxMovimentoObservacoesRawMap : IEntityTypeConfiguration<LinxMovimentoObservacoes>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoObservacoes> builder)
        {
            builder.ToTable("LinxMovimentoObservacoes", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_obs)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.titulo_obs)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.descricao_obs)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
