using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxRotinaOrigemMap : IEntityTypeConfiguration<LinxRotinaOrigem>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxRotinaOrigem> builder)
        {
            builder.ToTable("LinxRotinaOrigem");

            builder.HasKey(e => e.codigo_rotina);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_rotina)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao_rotina)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
