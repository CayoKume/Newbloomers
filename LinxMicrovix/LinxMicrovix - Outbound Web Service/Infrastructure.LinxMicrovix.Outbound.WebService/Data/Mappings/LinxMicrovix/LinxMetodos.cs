using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMetodosMap : IEntityTypeConfiguration<LinxMetodos>
    {
        public void Configure(EntityTypeBuilder<LinxMetodos> builder)
        {
            builder.ToTable("LinxMetodos", "linx_microvix_erp");

            builder.HasKey(e => e.methodID);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.methodID)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Retorno)
                .HasProviderColumnType(LogicalColumnType.Varchar_Max);
        }
    }

    public class LinxMetodosRawMap : IEntityTypeConfiguration<LinxMetodos>
    {
        public void Configure(EntityTypeBuilder<LinxMetodos> builder)
        {
            builder.ToTable("LinxMetodos", "untreated");

            builder.HasKey(e => e.methodID);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.methodID)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Retorno)
                .HasProviderColumnType(LogicalColumnType.Varchar_Max);
        }
    }
}
