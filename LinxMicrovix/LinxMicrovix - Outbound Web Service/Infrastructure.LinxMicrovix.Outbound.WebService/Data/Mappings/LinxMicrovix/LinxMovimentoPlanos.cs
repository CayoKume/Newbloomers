using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoPlanosMap : IEntityTypeConfiguration<LinxMovimentoPlanos>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoPlanos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoPlanos));

            builder.ToTable("LinxMovimentoPlanos");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new
                {
                    e.cnpj_emp,
                    e.identificador,
                    e.plano
                });
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

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.plano)
                .HasColumnType("int");

            builder.Property(e => e.desc_plano)
                .HasColumnType("varchar(35)");

            builder.Property(e => e.total)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.qtde_parcelas)
                .HasColumnType("int");

            builder.Property(e => e.indice_plano)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cod_forma_pgto)
                .HasColumnType("int");

            builder.Property(e => e.forma_pgto)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.tipo_transacao)
                .HasColumnType("char(1)");

            builder.Property(e => e.taxa_financeira)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.ordem_cartao)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.empresa)
                .HasColumnType("int");
        }
    }
}
