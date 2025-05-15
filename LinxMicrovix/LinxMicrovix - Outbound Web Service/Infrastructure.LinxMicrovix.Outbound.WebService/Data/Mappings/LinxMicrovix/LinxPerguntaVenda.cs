using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPerguntaVendaTrustedMap : IEntityTypeConfiguration<LinxPerguntaVenda>
    {
        public void Configure(EntityTypeBuilder<LinxPerguntaVenda> builder)
        {
            builder.ToTable("LinxPerguntaVenda", "linx_microvix_erp");

            builder.HasKey(e => e.id_pergunta_venda);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_pergunta_venda)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao_pergunta)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxPerguntaVendaRawMap : IEntityTypeConfiguration<LinxPerguntaVenda>
    {
        public void Configure(EntityTypeBuilder<LinxPerguntaVenda> builder)
        {
            builder.ToTable("LinxPerguntaVenda", "untreated");

            builder.HasKey(e => e.id_pergunta_venda);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_pergunta_venda)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao_pergunta)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
