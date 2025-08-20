using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxNfceEstacaoMap : IEntityTypeConfiguration<LinxNfceEstacao>
    {
        public void Configure(EntityTypeBuilder<LinxNfceEstacao> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxNfceEstacao));

            builder.ToTable("LinxNfceEstacao");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_nfce_estacao);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_nfce_estacao)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.numero_pdv_tef)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
