using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoCartoesTrustedMap : IEntityTypeConfiguration<LinxMovimentoCartoes>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoCartoes> builder)
        {
            builder.ToTable("LinxMovimentoCartoes", "linx_microvix_erp");

            builder.HasKey(e => new { 
                e.identificador, 
                e.cnpj_emp, 
                e.cupomfiscal, 
                e.cod_autorizacao 
            });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.codlojasitef)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.data_lancamento)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cupomfiscal)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.credito_debito)
                .HasColumnType("varchar(1)");

            builder.Property(e => e.id_cartao_bandeira)
                .HasColumnType("int");

            builder.Property(e => e.descricao_bandeira)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.ordem_cartao)
                .HasColumnType("int");

            builder.Property(e => e.nsu_host)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.nsu_sitef)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.cod_autorizacao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.id_antecipacoes_financeiras)
                .HasColumnType("int");

            builder.Property(e => e.transacao_servico_terceiro)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.texto_comprovante)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.id_maquineta_pos)
                .HasColumnType("int");

            builder.Property(e => e.descricao_maquineta)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.serie_maquineta)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.cartao_prepago)
                .HasColumnType("varchar(1)");
        }
    }

    public class LinxMovimentoCartoesRawMap : IEntityTypeConfiguration<LinxMovimentoCartoes>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoCartoes> builder)
        {
            builder.ToTable("LinxMovimentoCartoes", "untreated");

            builder.HasKey(e => new {
                e.identificador,
                e.cnpj_emp,
                e.cupomfiscal,
                e.cod_autorizacao
            });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.codlojasitef)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.data_lancamento)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cupomfiscal)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.credito_debito)
                .HasColumnType("varchar(1)");

            builder.Property(e => e.id_cartao_bandeira)
                .HasColumnType("int");

            builder.Property(e => e.descricao_bandeira)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.ordem_cartao)
                .HasColumnType("int");

            builder.Property(e => e.nsu_host)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.nsu_sitef)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.cod_autorizacao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.id_antecipacoes_financeiras)
                .HasColumnType("int");

            builder.Property(e => e.transacao_servico_terceiro)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.texto_comprovante)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.id_maquineta_pos)
                .HasColumnType("int");

            builder.Property(e => e.descricao_maquineta)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.serie_maquineta)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.cartao_prepago)
                .HasColumnType("varchar(1)");
        }
    }
}
