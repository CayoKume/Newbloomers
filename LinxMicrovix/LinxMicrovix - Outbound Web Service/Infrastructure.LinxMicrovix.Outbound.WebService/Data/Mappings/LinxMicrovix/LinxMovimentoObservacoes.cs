using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoObservacoesMap : IEntityTypeConfiguration<LinxMovimentoObservacoes>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxMovimentoObservacoes> builder)
        {
            builder.ToTable("LinxMovimentoObservacoes");

            builder.HasKey(e => e.id_obs);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_obs)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.titulo_obs)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.descricao_obs)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
