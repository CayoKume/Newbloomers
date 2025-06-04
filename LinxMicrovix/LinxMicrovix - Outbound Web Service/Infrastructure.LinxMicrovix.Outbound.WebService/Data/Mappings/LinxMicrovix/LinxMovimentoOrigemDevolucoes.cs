using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoOrigemDevolucoesMap : IEntityTypeConfiguration<LinxMovimentoOrigemDevolucoes>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoOrigemDevolucoes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoOrigemDevolucoes));

            builder.ToTable("LinxMovimentoOrigemDevolucoes");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.identificador);
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

            builder.Property(e => e.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.nota_origem)
                .HasColumnType("int");

            builder.Property(e => e.ecf_origem)
                .HasColumnType("int");

            builder.Property(e => e.data_origem)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.serie_origem)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
