using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxFechamentoCaixaMap : IEntityTypeConfiguration<LinxFechamentoCaixa>
    {
        public void Configure(EntityTypeBuilder<LinxFechamentoCaixa> builder)
        {
            builder.ToTable("LinxFechamentoCaixa", "linx_microvix_erp");

            builder.HasKey(e => e.empresa);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.conferencia_efetuada)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.data)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.obs)
                .HasColumnType("text");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.qtd_001)
                .HasColumnType("int");

            builder.Property(e => e.qtd_005)
                .HasColumnType("int");

            builder.Property(e => e.qtd_010)
                .HasColumnType("int");

            builder.Property(e => e.qtd_025)
                .HasColumnType("int");

            builder.Property(e => e.qtd_050)
                .HasColumnType("int");

            builder.Property(e => e.qtd_1)
                .HasColumnType("int");

            builder.Property(e => e.qtd_10)
                .HasColumnType("int");

            builder.Property(e => e.qtd_100)
                .HasColumnType("int");

            builder.Property(e => e.qtd_2)
                .HasColumnType("int");

            builder.Property(e => e.qtd_20)
                .HasColumnType("int");

            builder.Property(e => e.qtd_200)
                .HasColumnType("int");

            builder.Property(e => e.qtd_5)
                .HasColumnType("int");

            builder.Property(e => e.qtd_50)
                .HasColumnType("int");

            builder.Property(e => e.sangria)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.suprimentos)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_c_prazo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_c_vista)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_cartao)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_cartao_credito)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_cartao_debito)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_convenio)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_crediario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_geral)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_giftcard)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_link_pagamento)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_link_pagamento_credito)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_link_pagamento_debito)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_pix)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_qr_linx)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_vale_compra)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.usuario)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.vale_compras_dev)
                .HasColumnType("decimal(10,2)");
        }
    }

    public class LinxFechamentoCaixaRawMap : IEntityTypeConfiguration<LinxFechamentoCaixa>
    {
        public void Configure(EntityTypeBuilder<LinxFechamentoCaixa> builder)
        {
            builder.ToTable("LinxFechamentoCaixa", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.conferencia_efetuada)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.data)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.obs)
                .HasColumnType("text");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.qtd_001)
                .HasColumnType("int");

            builder.Property(e => e.qtd_005)
                .HasColumnType("int");

            builder.Property(e => e.qtd_010)
                .HasColumnType("int");

            builder.Property(e => e.qtd_025)
                .HasColumnType("int");

            builder.Property(e => e.qtd_050)
                .HasColumnType("int");

            builder.Property(e => e.qtd_1)
                .HasColumnType("int");

            builder.Property(e => e.qtd_10)
                .HasColumnType("int");

            builder.Property(e => e.qtd_100)
                .HasColumnType("int");

            builder.Property(e => e.qtd_2)
                .HasColumnType("int");

            builder.Property(e => e.qtd_20)
                .HasColumnType("int");

            builder.Property(e => e.qtd_200)
                .HasColumnType("int");

            builder.Property(e => e.qtd_5)
                .HasColumnType("int");

            builder.Property(e => e.qtd_50)
                .HasColumnType("int");

            builder.Property(e => e.sangria)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.suprimentos)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_c_prazo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_c_vista)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_cartao)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_cartao_credito)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_cartao_debito)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_convenio)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_crediario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_geral)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_giftcard)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_link_pagamento)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_link_pagamento_credito)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_link_pagamento_debito)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_pix)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_qr_linx)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.total_vale_compra)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.usuario)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.vale_compras_dev)
                .HasColumnType("decimal(10,2)");
        }
    }
}
