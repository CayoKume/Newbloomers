using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxECFMap : IEntityTypeConfiguration<LinxECF>
    {
        public void Configure(EntityTypeBuilder<LinxECF> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxECF));

            builder.ToTable("LinxECF");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_ecf);
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

            builder.Property(e => e.id_ecf)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.ecf)
                .HasColumnType("int");

            builder.Property(e => e.numeroserie)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.indice_sangria)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.modelo)
                .HasColumnType("int");

            builder.Property(e => e.nome)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.indice_suprimento)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.ativo)
                .HasColumnType("int");

            builder.Property(e => e.indice_sinal)
                .HasColumnType("varchar(53)");

            builder.Property(e => e.indice_antecipacao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.indice_cartao_credito)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.empresa_ecf)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
