using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxOticoPrismaDescricaoMap : IEntityTypeConfiguration<LinxOticoPrismaDescricao>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxOticoPrismaDescricao> builder)
        {
            builder.ToTable("LinxOticoPrismaDescricao");

            builder.HasKey(e => e.id_otico_prisma_descricao);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_otico_prisma_descricao)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
