using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPlanosParcelasMap : IEntityTypeConfiguration<B2CConsultaPlanosParcelas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPlanosParcelas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaPlanosParcelas));

            builder.ToTable("B2CConsultaPlanosParcelas");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.plano);
                builder.Ignore(e => e.id);
            }
            else
            {
                builder.HasKey(e => e.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }
            
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.plano)
                .HasColumnType("int");

            builder.Property(e => e.ordem_parcela)
                .HasColumnType("int");

            builder.Property(e => e.prazo_parc)
                .HasColumnType("int");

            builder.Property(e => e.id_planos_parcelas)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
