using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Enums;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoCamposAdicionaisMap : IEntityTypeConfiguration<LinxMovimentoCamposAdicionais>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxMovimentoCamposAdicionais> builder)
        {
            builder.ToTable("LinxMovimentoCamposAdicionais");

            builder.HasKey(e => e.id_ordservprod);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_ordservprod)
                .HasColumnType("int");

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.paciente)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.codigo_gerencial)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
