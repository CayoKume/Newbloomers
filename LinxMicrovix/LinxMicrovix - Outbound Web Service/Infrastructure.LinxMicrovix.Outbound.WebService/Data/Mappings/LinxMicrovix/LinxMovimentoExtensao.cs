using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoExtensaoMap : IEntityTypeConfiguration<LinxMovimentoExtensao>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoExtensao> builder)
        {
            builder.ToTable("LinxMovimentoExtensao", "linx_microvix_erp");

            builder.HasKey(e => e.identificador);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.base_fcp_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_fcp_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliq_fcp_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_icms_fcp_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_icms_fcp_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_icms_fcp_st_retido)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_icms_fcp_st_retido)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_icms_fcp_st_antecipado)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_icms_fcp_st_antecipado)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliquota_icms_fcp_st_antecipado)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.valor_iss)
                .HasColumnType("int");

            builder.Property(e => e.tipo_tributacao_iss)
                .HasColumnType("int");

            builder.Property(e => e.icms_fcp_aliquota)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_fcp_base_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_fcp_valor_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_base_partilha)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliq_difal_interna_uf_destinatario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliq_difal_interestadual_uf_envolvidas)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_item_perc_partilha_destino)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_item_perc_partilha_origem)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.codigo_pacote)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_itens_associados)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_kit)
                .HasColumnType("bigint");

            builder.Property(e => e.id_motivo_desconto)
                .HasColumnType("int");

            builder.Property(e => e.icms_st_antecipado_base_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_suportado_valor_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_suportado_valor_unitario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_st_pago_base)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_st_pago_valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_st_pago_aliq)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_para_st_pago_valor)
                .HasColumnType("decimal(10,2)");
        }
    }

    public class LinxMovimentoExtensaoRawMap : IEntityTypeConfiguration<LinxMovimentoExtensao>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoExtensao> builder)
        {
            builder.ToTable("LinxMovimentoExtensao", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.base_fcp_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_fcp_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliq_fcp_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_icms_fcp_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_icms_fcp_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_icms_fcp_st_retido)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_icms_fcp_st_retido)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_icms_fcp_st_antecipado)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_icms_fcp_st_antecipado)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliquota_icms_fcp_st_antecipado)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.valor_iss)
                .HasColumnType("int");

            builder.Property(e => e.tipo_tributacao_iss)
                .HasColumnType("int");

            builder.Property(e => e.icms_fcp_aliquota)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_fcp_base_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_fcp_valor_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_base_partilha)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliq_difal_interna_uf_destinatario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliq_difal_interestadual_uf_envolvidas)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_item_perc_partilha_destino)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_item_perc_partilha_origem)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.codigo_pacote)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_itens_associados)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_kit)
                .HasColumnType("bigint");

            builder.Property(e => e.id_motivo_desconto)
                .HasColumnType("int");

            builder.Property(e => e.icms_st_antecipado_base_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_suportado_valor_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_suportado_valor_unitario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_st_pago_base)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_st_pago_valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_st_pago_aliq)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_para_st_pago_valor)
                .HasColumnType("decimal(10,2)");
        }
    }
}
