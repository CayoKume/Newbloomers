using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoOrigemDevolucoesTrustedMap : IEntityTypeConfiguration<LinxMovimentoOrigemDevolucoes>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoOrigemDevolucoes> builder)
        {
            builder.ToTable("LinxMovimentoOrigemDevolucoes", "linx_microvix_erp");

            builder.HasKey(e => e.identificador);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.nota_origem)
                .HasColumnType("int");

            builder.Property(e => e.ecf_origem)
                .HasColumnType("int");

            builder.Property(e => e.data_origem)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.serie_origem)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxMovimentoOrigemDevolucoesRawMap : IEntityTypeConfiguration<LinxMovimentoOrigemDevolucoes>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoOrigemDevolucoes> builder)
        {
            builder.ToTable("LinxMovimentoOrigemDevolucoes", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.nota_origem)
                .HasColumnType("int");

            builder.Property(e => e.ecf_origem)
                .HasColumnType("int");

            builder.Property(e => e.data_origem)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.serie_origem)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
