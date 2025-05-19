using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxRamosAtividadeMap : IEntityTypeConfiguration<LinxRamosAtividade>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxRamosAtividade> builder)
        {
            builder.ToTable("LinxRamosAtividade");

            builder.HasKey(e => e.id_ramo_atividade);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_ramo_atividade)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.nome_ramo_atividade)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.codigo_ramo_atividade)
                .HasColumnType("varchar(12)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
