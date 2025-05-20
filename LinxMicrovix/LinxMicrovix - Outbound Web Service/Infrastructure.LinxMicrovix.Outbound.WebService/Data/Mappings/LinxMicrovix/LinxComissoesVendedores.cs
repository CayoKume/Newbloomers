using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxComissoesVendedoresMap : IEntityTypeConfiguration<LinxComissoesVendedores>
    {
        public void Configure(EntityTypeBuilder<LinxComissoesVendedores> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxComissoesVendedores));

            builder.ToTable("LinxComissoesVendedores");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.vendedor);
                builder.Ignore(x => x.id);
            }
            else
            {
                builder.HasKey(x => x.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.vendedor)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.data_origem)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.valor_base)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_comissao)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cancelado)
                .HasColumnType("char(1)");

            builder.Property(e => e.disponivel)
                .HasColumnType("char(1)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
