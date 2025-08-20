using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxValeOrdemServicoExternaMap : IEntityTypeConfiguration<LinxValeOrdemServicoExterna>
    {
        public void Configure(EntityTypeBuilder<LinxValeOrdemServicoExterna> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxValeOrdemServicoExterna));

            builder.ToTable("LinxValeOrdemServicoExterna");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_vale_ordem_servico_externa);
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

            builder.Property(e => e.id_vale_ordem_servico_externa)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.numero_controle)
                .HasColumnType("varchar(25)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
