using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaStatusMap : IEntityTypeConfiguration<LinxDevolucaoRemanejoFabricaStatus>
    {
        public void Configure(EntityTypeBuilder<LinxDevolucaoRemanejoFabricaStatus> builder)
        {
            builder.ToTable("LinxDevolucaoRemanejoFabricaStatus", "linx_microvix_erp");

            builder.HasKey(e => e.id_devolucao_remanejo_fabrica_status);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_devolucao_remanejo_fabrica_status)
                .HasColumnType("int");

            builder.Property(e => e.id_devolucao_remanejo_fabrica_tipo)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxDevolucaoRemanejoFabricaStatusRawMap : IEntityTypeConfiguration<LinxDevolucaoRemanejoFabricaStatus>
    {
        public void Configure(EntityTypeBuilder<LinxDevolucaoRemanejoFabricaStatus> builder)
        {
            builder.ToTable("LinxDevolucaoRemanejoFabricaStatus", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_devolucao_remanejo_fabrica_status)
                .HasColumnType("int");

            builder.Property(e => e.id_devolucao_remanejo_fabrica_tipo)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
