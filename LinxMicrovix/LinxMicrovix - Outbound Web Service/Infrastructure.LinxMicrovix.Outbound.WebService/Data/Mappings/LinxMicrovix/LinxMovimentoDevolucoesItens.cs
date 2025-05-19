using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoDevolucoesItensMap : IEntityTypeConfiguration<LinxMovimentoDevolucoesItens>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxMovimentoDevolucoesItens> builder)
        {
            builder.ToTable("LinxMovimentoDevolucoesItens");

            builder.HasKey(e => e.id_movimento_devolucoes_itens);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_movimento_devolucoes_itens)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.identificador_venda)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.identificador_devolucao)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.transacao_origem)
                .HasColumnType("int");

            builder.Property(e => e.transacao_devolucao)
                .HasColumnType("int");

            builder.Property(e => e.qtde_devolvida)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
