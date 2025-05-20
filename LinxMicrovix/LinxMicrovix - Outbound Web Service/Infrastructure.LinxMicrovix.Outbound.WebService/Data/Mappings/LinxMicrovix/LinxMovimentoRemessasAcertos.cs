using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoRemessasAcertosMap : IEntityTypeConfiguration<LinxMovimentoRemessasAcertos>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoRemessasAcertos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoRemessasAcertos));

            builder.ToTable("LinxMovimentoRemessasAcertos");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_remessas_acertos);
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

            builder.Property(e => e.id_remessas_acertos)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.id_remessas)
                .HasColumnType("int");

            builder.Property(e => e.identificador_venda)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.identificador_retorno)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.identificador_devolucao)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.data)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_vendas_pos)
                .HasColumnType("bigint");

            builder.Property(e => e.excluido)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
