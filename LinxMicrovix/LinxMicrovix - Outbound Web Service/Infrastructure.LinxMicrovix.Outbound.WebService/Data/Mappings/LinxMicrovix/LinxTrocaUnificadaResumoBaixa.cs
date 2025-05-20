using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoBaixaMap : IEntityTypeConfiguration<LinxTrocaUnificadaResumoBaixa>
    {
        public void Configure(EntityTypeBuilder<LinxTrocaUnificadaResumoBaixa> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxTrocaUnificadaResumoBaixa));

            builder.ToTable("LinxTrocaUnificadaResumoBaixa");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_troca_unificada_resumo_vendas_itens);
                builder.Ignore(x => x.id);
            }
            else
            {
                builder.HasKey(x => x.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }

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
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.transacao_baixa)
                .HasColumnType("int");

            builder.Property(e => e.descricao_empresa_baixa)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
