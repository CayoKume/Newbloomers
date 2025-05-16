using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxRespostaVendaMap : IEntityTypeConfiguration<LinxRespostaVenda>
    {
        public void Configure(EntityTypeBuilder<LinxRespostaVenda> builder)
        {
            builder.ToTable("LinxRespostaVenda", "linx_microvix_erp");

            builder.HasKey(e => e.id_resposta_venda);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_resposta_venda)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao_resposta)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.id_pergunta_venda)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxRespostaVendaRawMap : IEntityTypeConfiguration<LinxRespostaVenda>
    {
        public void Configure(EntityTypeBuilder<LinxRespostaVenda> builder)
        {
            builder.ToTable("LinxRespostaVenda", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_resposta_venda)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao_resposta)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.id_pergunta_venda)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
