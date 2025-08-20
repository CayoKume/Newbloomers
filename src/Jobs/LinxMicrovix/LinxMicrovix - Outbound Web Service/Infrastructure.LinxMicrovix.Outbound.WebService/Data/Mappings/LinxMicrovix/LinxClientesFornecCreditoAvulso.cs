using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Infrastructure.Core.Data.Schemas;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxClientesFornecCreditoAvulsoMap : IEntityTypeConfiguration<LinxClientesFornecCreditoAvulso>
    {
        public void Configure(EntityTypeBuilder<LinxClientesFornecCreditoAvulso> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxClientesFornecCreditoAvulso));

            builder.ToTable("LinxClientesFornecCreditoAvulso");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.cod_cliente);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente)
                .HasColumnType("int");

            builder.Property(e => e.controle)
                .HasColumnType("int");

            builder.Property(e => e.data)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.cd)
                .HasColumnType("char(1)");

            builder.Property(e => e.valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.motivo)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");
        }
    }
}
