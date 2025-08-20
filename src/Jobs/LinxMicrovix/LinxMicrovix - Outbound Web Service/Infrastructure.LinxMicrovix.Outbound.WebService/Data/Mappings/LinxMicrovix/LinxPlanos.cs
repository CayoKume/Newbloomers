using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPlanosMap : IEntityTypeConfiguration<LinxPlanos>
    {
        public void Configure(EntityTypeBuilder<LinxPlanos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxPlanos));

            builder.ToTable("LinxPlanos");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.plano);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.plano)
                .HasColumnType("int");

            builder.Property(e => e.desc_plano)
                .HasColumnType("varchar(35)");

            builder.Property(e => e.qtde_parcelas)
                .HasColumnType("int");

            builder.Property(e => e.prazo_entre_parcelas)
                .HasColumnType("int");

            builder.Property(e => e.tipo_plano)
                .HasColumnType("char(1)");

            builder.Property(e => e.indice_plano)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cod_forma_pgto)
                .HasColumnType("int");

            builder.Property(e => e.forma_pgto)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.conta_central)
                .HasColumnType("int");

            builder.Property(e => e.tipo_transacao)
                .HasColumnType("char(1)");

            builder.Property(e => e.taxa_financeira)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.dt_upd)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.desativado)
                .HasColumnType("char(1)");

            builder.Property(e => e.usa_tef)
                .HasColumnType("char(1)");

            builder.Property(e => e.timestamp)
                .HasColumnType("int");
        }
    }
}
