using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Infrastructure.Core.Data.Schemas;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxGrupoLojasMap : IEntityTypeConfiguration<LinxGrupoLojas>
    {
        public void Configure(EntityTypeBuilder<LinxGrupoLojas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxGrupoLojas));

            builder.ToTable("LinxGrupoLojas");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_empresas_rede);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.cnpj)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.nome_empresa)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.id_empresas_rede)
                .HasColumnType("int");

            builder.Property(e => e.rede)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.nome_portal)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.classificacao_portal)
                .HasColumnType("varchar(50)");
        }
    }
}
