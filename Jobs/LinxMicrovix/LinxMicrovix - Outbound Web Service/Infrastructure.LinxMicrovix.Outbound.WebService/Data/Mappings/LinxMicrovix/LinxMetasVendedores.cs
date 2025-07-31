using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMetasVendedoresMap : IEntityTypeConfiguration<LinxMetasVendedores>
    {
        public void Configure(EntityTypeBuilder<LinxMetasVendedores> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMetasVendedores));

            builder.ToTable("LinxMetasVendedores");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_meta);
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

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_meta)
                .HasColumnType("int");

            builder.Property(e => e.descricao_meta)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.data_inicial_meta)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.data_final_meta)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.valor_meta_loja)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_meta_vendedor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cod_vendedor)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
