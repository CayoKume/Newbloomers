using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxXMLDocumentosMap : IEntityTypeConfiguration<LinxXMLDocumentos>
    {
        public void Configure(EntityTypeBuilder<LinxXMLDocumentos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxXMLDocumentos));

            builder.ToTable("LinxXMLDocumentos");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new { e.cnpj_emp, e.documento, e.chave_nfe });
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

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.serie)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.data_emissao)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.chave_nfe)
                .HasColumnType("varchar(44)");

            builder.Property(e => e.situacao)
                .HasColumnType("int");

            builder.Property(e => e.xml)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.excluido)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.identificador_microvix)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.dt_insert)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.nProtCanc)
                .HasColumnType("varchar(15)");

            builder.Property(e => e.nProtInut)
                .HasColumnType("varchar(15)");

            builder.Property(e => e.xmlDistribuicao)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.nProtDeneg)
                .HasColumnType("varchar(15)");

            builder.Property(e => e.cStat)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.id_nfe)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente)
                .HasColumnType("int");
        }
    }
}
