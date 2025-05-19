using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxListagemBalancoMap : IEntityTypeConfiguration<LinxListagemBalanco>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxListagemBalanco> builder)
        {
            builder.ToTable("LinxListagemBalanco");

            builder.HasKey(e => e.id_balanco);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_balanco)
                .HasColumnType("int");

            builder.Property(e => e.data)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.nome_arquivo)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.processado)
                .HasColumnType("varchar(1)");

            builder.Property(e => e.data_ultimo_processamento)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.qtde_produtos)
                .HasColumnType("int");

            builder.Property(e => e.qtde_itens)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
