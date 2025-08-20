using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoRemessasAcertosItensMap : IEntityTypeConfiguration<LinxMovimentoRemessasAcertosItens>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoRemessasAcertosItens> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoRemessasAcertosItens));

            builder.ToTable("LinxMovimentoRemessasAcertosItens");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_remessas_acertos);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_remessas_acertos)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.qtde_total)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_remessa_operacoes)
                .HasColumnType("int");

            builder.Property(e => e.id_remessas_itens)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
