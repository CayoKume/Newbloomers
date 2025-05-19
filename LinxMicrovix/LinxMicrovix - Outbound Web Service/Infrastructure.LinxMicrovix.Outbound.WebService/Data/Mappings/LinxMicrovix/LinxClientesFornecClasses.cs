using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxClientesFornecClassesMap : IEntityTypeConfiguration<LinxClientesFornecClasses>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxClientesFornecClasses> builder)
        {
            builder.ToTable("LinxClientesFornecClasses");

            builder.HasKey(e => new { e.cod_cliente, e.cod_classe });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente)
                .HasColumnType("int");

            builder.Property(e => e.cod_classe)
                .HasColumnType("int");

            builder.Property(e => e.nome_classe)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
