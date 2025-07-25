using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxAntecipacoesFinanceirasPlanosMap : IEntityTypeConfiguration<LinxAntecipacoesFinanceirasPlanos>
    {
        public void Configure(EntityTypeBuilder<LinxAntecipacoesFinanceirasPlanos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxAntecipacoesFinanceirasPlanos));

            builder.ToTable("LinxAntecipacoesFinanceirasPlanos");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(x => x.plano);
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
                .Property(x => x.plano)
                .HasColumnType("int");

            builder
                .Property(x => x.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder
                .Property(x => x.forma_pgto)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.nome_plano)
                .HasColumnType("varchar(35)");

            builder
                .Property(x => x.codigo_gerencial)
                .HasColumnType("varchar(20)");

            builder
                .Property(x => x.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.previsao_entrega)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.cancelado)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.portal)
                .HasColumnType("int");

            builder
                .Property(x => x.valor)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.id_antecipacoes_financeiras)
                .HasColumnType("int");

            builder
                .Property(x => x.numero_antecipacao)
                .HasColumnType("int");

            builder
                .Property(x => x.id_ordservprod)
                .HasColumnType("int");

            builder
                .Property(x => x.id_vendas_pos_produtos_tmp)
                .HasColumnType("int");

            builder
                .Property(x => x.id_vendas_pos)
                .HasColumnType("int");

            builder
                .Property(x => x.id_vendas_pos_produtos_campos_adicionais_tmp)
                .HasColumnType("int");

            builder
                .Property(x => x.id_link_pagamento_linx_pay_hub)
                .HasColumnType("int");

            builder
                .Property(x => x.empresa)
                .HasColumnType("int");

            builder
                .Property(x => x.timestamp)
                .HasColumnType("bigint");

            builder
                .Property(x => x.numero_ficha)
                .HasColumnType("bigint");
        }
    }
}
