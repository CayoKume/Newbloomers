using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxListaDaVezMap : IEntityTypeConfiguration<LinxListaDaVez>
    {
        public void Configure(EntityTypeBuilder<LinxListaDaVez> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxListaDaVez));

            builder.ToTable("LinxListaDaVez");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new { e.cnpj_emp, e.cod_vendedor, e.data });
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

            builder.Property(e => e.cod_vendedor)
                .HasColumnType("int");

            builder.Property(e => e.data)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.motivo_nao_venda)
                .HasColumnType("varchar(103)");

            builder.Property(e => e.qtde_ocorrencias)
                .HasColumnType("int");

            builder.Property(e => e.data_hora_ini_atend)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.data_hora_fim_atend)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.obs)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.desc_produto_neg)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.valor_produto_neg)
                .HasColumnType("decimal(10,2)");
        }
    }
}
