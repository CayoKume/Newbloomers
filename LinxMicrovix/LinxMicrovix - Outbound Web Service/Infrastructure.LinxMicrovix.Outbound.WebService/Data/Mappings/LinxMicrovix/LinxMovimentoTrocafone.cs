using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoTrocafoneMap : IEntityTypeConfiguration<LinxMovimentoTrocafone>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoTrocafone> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoTrocafone));

            builder.ToTable("LinxMovimentoTrocafone");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.num_vale);
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

            builder.Property(e => e.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.num_vale)
                .HasColumnType("bigint");

            builder.Property(e => e.voucher)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.valor_vale)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.nome_produto)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.condicao)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.id_tradein_parceiro)
                .HasColumnType("int");
        }
    }
}
