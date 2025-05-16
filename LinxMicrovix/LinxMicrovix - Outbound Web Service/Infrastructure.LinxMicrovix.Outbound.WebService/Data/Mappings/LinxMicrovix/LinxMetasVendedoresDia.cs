using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMetasVendedoresDiaMap : IEntityTypeConfiguration<LinxMetasVendedoresDia>
    {
        public void Configure(EntityTypeBuilder<LinxMetasVendedoresDia> builder)
        {
            builder.ToTable("LinxMetasVendedoresDia", "linx_microvix_erp");

            builder.HasKey(e => e.id_meta);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_meta)
                .HasColumnType("int");

            builder.Property(e => e.descricao_meta)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.data_inicial_meta)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.data_final_meta)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.dia)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.valor_meta_diaria)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cod_vendedor)
                .HasColumnType("int");
        }
    }

    public class LinxMetasVendedoresDiaRawMap : IEntityTypeConfiguration<LinxMetasVendedoresDia>
    {
        public void Configure(EntityTypeBuilder<LinxMetasVendedoresDia> builder)
        {
            builder.ToTable("LinxMetasVendedoresDia", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_meta)
                .HasColumnType("int");

            builder.Property(e => e.descricao_meta)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.data_inicial_meta)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.data_final_meta)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.dia)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.valor_meta_diaria)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cod_vendedor)
                .HasColumnType("int");
        }
    }
}
