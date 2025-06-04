using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxAntecipacoesFinanceirasMap : IEntityTypeConfiguration<LinxAntecipacoesFinanceiras>
    {
        public void Configure(EntityTypeBuilder<LinxAntecipacoesFinanceiras> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxAntecipacoesFinanceiras));

            builder.ToTable("LinxAntecipacoesFinanceiras");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(x => x.id_antecipacoes_financeiras);
                builder.Ignore(x => x.id);
            }
            else
            {
                builder.HasKey(x => x.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }

            builder
                .Property(x => x.id_antecipacoes_financeiras)
                .HasColumnType("int");

            builder
                .Property(x => x.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.data_antecipacao)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.previsao_entrega)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder
                .Property(x => x.cancelado)
                .HasProviderColumnType(EnumTableColumnType.Bool);

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
