using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoBaixaTrustedMap : IEntityTypeConfiguration<LinxTrocaUnificadaResumoBaixa>
    {
        public void Configure(EntityTypeBuilder<LinxTrocaUnificadaResumoBaixa> builder)
        {
            builder.ToTable("LinxTrocaUnificadaResumoBaixa", "linx_microvix_erp");

            builder.HasKey(e => e.id_troca_unificada_resumo_vendas_itens);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal_baixa)
                .HasColumnType("int");

            builder.Property(e => e.empresa_baixa)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_empresa_baixa)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_troca_baixa)
                .HasColumnType("int");

            builder.Property(e => e.id_troca_unificada_resumo_vendas_itens)
                .HasColumnType("bigint");

            builder.Property(e => e.data_troca_baixa)
                .HasColumnType("int");

            builder.Property(e => e.transacao_baixa)
                .HasColumnType("int");

            builder.Property(e => e.descricao_empresa_baixa)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxTrocaUnificadaResumoBaixaRawMap : IEntityTypeConfiguration<LinxTrocaUnificadaResumoBaixa>
    {
        public void Configure(EntityTypeBuilder<LinxTrocaUnificadaResumoBaixa> builder)
        {
            builder.ToTable("LinxTrocaUnificadaResumoBaixa", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal_baixa)
                .HasColumnType("int");

            builder.Property(e => e.empresa_baixa)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_empresa_baixa)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_troca_baixa)
                .HasColumnType("int");

            builder.Property(e => e.id_troca_unificada_resumo_vendas_itens)
                .HasColumnType("bigint");

            builder.Property(e => e.data_troca_baixa)
                .HasColumnType("int");

            builder.Property(e => e.transacao_baixa)
                .HasColumnType("int");

            builder.Property(e => e.descricao_empresa_baixa)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
