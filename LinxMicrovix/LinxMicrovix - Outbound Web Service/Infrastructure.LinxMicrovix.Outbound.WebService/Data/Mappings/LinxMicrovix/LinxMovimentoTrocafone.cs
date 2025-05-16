using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoTrocafoneTrustedMap : IEntityTypeConfiguration<LinxMovimentoTrocafone>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoTrocafone> builder)
        {
            builder.ToTable("LinxMovimentoTrocafone", "linx_microvix_erp");

            builder.HasKey(e => e.num_vale);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.num_vale)
                .HasColumnType("bigint");

            builder.Property(e => e.voucher)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.valor_vale)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.nome_produto)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.condicao)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.id_tradein_parceiro)
                .HasColumnType("int");
        }
    }

    public class LinxMovimentoTrocafoneRawMap : IEntityTypeConfiguration<LinxMovimentoTrocafone>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoTrocafone> builder)
        {
            builder.ToTable("LinxMovimentoTrocafone", "untreated");

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

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.num_vale)
                .HasColumnType("bigint");

            builder.Property(e => e.voucher)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.valor_vale)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.nome_produto)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.condicao)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.id_tradein_parceiro)
                .HasColumnType("int");
        }
    }
}
