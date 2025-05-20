using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxLancContabilMap : IEntityTypeConfiguration<LinxLancContabil>
    {
        public void Configure(EntityTypeBuilder<LinxLancContabil> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxLancContabil));

            builder.ToTable("LinxLancContabil");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.cod_lanc);
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

            builder.Property(e => e.cod_lanc)
                .HasColumnType("bigint");

            builder.Property(e => e.centro_custo)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ind_conta)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.cod_conta)
                .HasColumnType("bigint");

            builder.Property(e => e.nome_conta)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.valor_conta)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cred_deb)
                .HasColumnType("varchar(1)");

            builder.Property(e => e.data_lanc)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.compl_conta)
                .HasColumnType("varchar(500)");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.cod_historico)
                .HasColumnType("bigint");

            builder.Property(e => e.desc_historico)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.data_compensacao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.fatura_origem)
                .HasColumnType("int");

            builder.Property(e => e.efetivado)
                .HasColumnType("varchar(1)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.id_lanc)
                .HasColumnType("bigint");

            builder.Property(e => e.cancelado)
                .HasColumnType("varchar(1)");
        }
    }
}
