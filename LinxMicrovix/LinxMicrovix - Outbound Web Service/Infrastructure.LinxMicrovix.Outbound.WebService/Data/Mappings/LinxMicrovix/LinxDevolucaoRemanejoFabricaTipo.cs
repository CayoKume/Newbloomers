using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaTipoMap : IEntityTypeConfiguration<LinxDevolucaoRemanejoFabricaTipo>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxDevolucaoRemanejoFabricaTipo> builder)
        {
            builder.ToTable("LinxDevolucaoRemanejoFabricaTipo");

            builder.HasKey(e => e.id_devolucao_remanejo_fabrica_tipo);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_devolucao_remanejo_fabrica_tipo)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
