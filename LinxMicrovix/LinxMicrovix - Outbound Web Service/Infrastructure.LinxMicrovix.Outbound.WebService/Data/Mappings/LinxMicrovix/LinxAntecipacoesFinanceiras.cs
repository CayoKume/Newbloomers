using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxAntecipacoesFinanceirasMap : IEntityTypeConfiguration<LinxAntecipacoesFinanceiras>
    {
        public void Configure(EntityTypeBuilder<LinxAntecipacoesFinanceiras> builder)
        {
            builder
                .ToTable("LinxAntecipacoesFinanceiras", "linx_microvix_erp")
                .HasKey(x => x.id_antecipacoes_financeiras);

            builder
                .Property(x => x.id_antecipacoes_financeiras)
                .HasColumnType("int");

            builder
                .Property(x => x.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder
                .Property(x => x.data_antecipacao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder
                .Property(x => x.previsao_entrega)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder
                .Property(x => x.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder
                .Property(x => x.cancelado)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder
                .Property(x => x.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder
                .Property(x => x.dav_pv)
                .HasColumnType("varchar(3)");

            builder
                .Property(x => x.entregue)
                .HasColumnType("varchar(1)");

            builder
                .Property(x => x.quantidade)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.preco_unitario_produto)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.valor_pago_antecipacao)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.portal)
                .HasColumnType("int");

            builder
                .Property(x => x.timestamp)
                .HasColumnType("bigint");

            builder
                .Property(x => x.empresa)
                .HasColumnType("int");

            builder
                .Property(x => x.cod_cliente)
                .HasColumnType("int");

            builder
                .Property(x => x.numero_antecipacao)
                .HasColumnType("int");

            builder
                .Property(x => x.numero_origem)
                .HasColumnType("int");

            builder
                .Property(x => x.dav_remessa)
                .HasColumnType("int");

            builder
                .Property(x => x.id_antecipacoes_financeiras_detalhes)
                .HasColumnType("int");

            builder
                .Property(x => x.id_vendas_pos_produtos)
                .HasColumnType("int");
        }
    }

    public class LinxAntecipacoesFinanceirasRawMap : IEntityTypeConfiguration<LinxAntecipacoesFinanceiras>
    {
        public void Configure(EntityTypeBuilder<LinxAntecipacoesFinanceiras> builder)
        {
            builder
                .ToTable("LinxAntecipacoesFinanceiras", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.id_antecipacoes_financeiras)
                .HasColumnType("int");

            builder
                .Property(x => x.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder
                .Property(x => x.data_antecipacao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder
                .Property(x => x.previsao_entrega)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder
                .Property(x => x.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder
                .Property(x => x.cancelado)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder
                .Property(x => x.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder
                .Property(x => x.dav_pv)
                .HasColumnType("varchar(3)");

            builder
                .Property(x => x.entregue)
                .HasColumnType("varchar(1)");

            builder
                .Property(x => x.quantidade)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.preco_unitario_produto)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.valor_pago_antecipacao)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.portal)
                .HasColumnType("int");

            builder
                .Property(x => x.timestamp)
                .HasColumnType("bigint");

            builder
                .Property(x => x.empresa)
                .HasColumnType("int");

            builder
                .Property(x => x.cod_cliente)
                .HasColumnType("int");

            builder
                .Property(x => x.numero_antecipacao)
                .HasColumnType("int");

            builder
                .Property(x => x.numero_origem)
                .HasColumnType("int");

            builder
                .Property(x => x.dav_remessa)
                .HasColumnType("int");

            builder
                .Property(x => x.id_antecipacoes_financeiras_detalhes)
                .HasColumnType("int");

            builder
                .Property(x => x.id_vendas_pos_produtos)
                .HasColumnType("int");
        }
    }
}
