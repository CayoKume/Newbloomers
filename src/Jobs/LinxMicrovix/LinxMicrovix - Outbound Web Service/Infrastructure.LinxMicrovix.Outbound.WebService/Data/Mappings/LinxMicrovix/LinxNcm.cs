using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxNcmMap : IEntityTypeConfiguration<LinxNcm>
    {
        public void Configure(EntityTypeBuilder<LinxNcm> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxNcm));

            builder.ToTable("LinxNcm");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_ncm);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.codigo)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.codigo_genero)
                .HasColumnType("int");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.id_ncm)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("int");
        }
    }
}
