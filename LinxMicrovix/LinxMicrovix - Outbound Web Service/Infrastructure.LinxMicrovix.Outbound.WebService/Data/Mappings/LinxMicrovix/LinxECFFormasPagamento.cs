using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxECFFormasPagamentoTrustedMap : IEntityTypeConfiguration<LinxECFFormasPagamento>
    {
        public void Configure(EntityTypeBuilder<LinxECFFormasPagamento> builder)
        {
            builder.ToTable("LinxECFFormasPagamento", "linx_microvix_erp");

            builder.HasKey(e => e.id_empresa_ecf_formas_pgto);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_empresa_ecf_formas_pgto)
                .HasColumnType("int");

            builder.Property(e => e.id_ecf)
                .HasColumnType("int");

            builder.Property(e => e.cod_forma_pgto)
                .HasColumnType("int");

            builder.Property(e => e.indice_forma)
                .HasColumnType("varchar(53)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxECFFormasPagamentoRawMap : IEntityTypeConfiguration<LinxECFFormasPagamento>
    {
        public void Configure(EntityTypeBuilder<LinxECFFormasPagamento> builder)
        {
            builder.ToTable("LinxECFFormasPagamento", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_empresa_ecf_formas_pgto)
                .HasColumnType("int");

            builder.Property(e => e.id_ecf)
                .HasColumnType("int");

            builder.Property(e => e.cod_forma_pgto)
                .HasColumnType("int");

            builder.Property(e => e.indice_forma)
                .HasColumnType("varchar(53)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
