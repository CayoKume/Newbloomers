using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxECFFormasPagamentoMap : IEntityTypeConfiguration<LinxECFFormasPagamento>
    {
        public void Configure(EntityTypeBuilder<LinxECFFormasPagamento> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxECFFormasPagamento));

            builder.ToTable("LinxECFFormasPagamento");

            if (schema == "linx_microvix_erp")
            { 
                builder.HasKey(e => e.id_empresa_ecf_formas_pgto);
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
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_empresa_ecf_formas_pgto)
                .HasColumnType("int");

            builder.Property(e => e.id_ecf)
                .HasColumnType("int");

            builder.Property(e => e.cod_forma_pgto)
                .HasColumnType("int");

            builder.Property(e => e.indice_forma)
                .HasColumnType("varchar(53)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
