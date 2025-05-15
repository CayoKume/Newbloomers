using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxXMLDocumentosTrustedMap : IEntityTypeConfiguration<LinxXMLDocumentos>
    {
        public void Configure(EntityTypeBuilder<LinxXMLDocumentos> builder)
        {
            builder.ToTable("LinxXMLDocumentos", "linx_microvix_erp");

            builder.HasKey(e => new { e.cnpj_emp, e.documento, e.chave_nfe });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.serie)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.data_emissao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.chave_nfe)
                .HasColumnType("varchar(44)");

            builder.Property(e => e.situacao)
                .HasColumnType("int");

            builder.Property(e => e.xml)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.excluido)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.identificador_microvix)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.dt_insert)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.nProtCanc)
                .HasColumnType("varchar(15)");

            builder.Property(e => e.nProtInut)
                .HasColumnType("varchar(15)");

            builder.Property(e => e.xmlDistribuicao)
                .HasColumnType("varchar(max)");

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

    public class LinxXMLDocumentosRawMap : IEntityTypeConfiguration<LinxXMLDocumentos>
    {
        public void Configure(EntityTypeBuilder<LinxXMLDocumentos> builder)
        {
            builder.ToTable("LinxXMLDocumentos", "untreated");

            builder.HasKey(e => new { e.cnpj_emp, e.documento, e.chave_nfe });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.serie)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.data_emissao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.chave_nfe)
                .HasColumnType("varchar(44)");

            builder.Property(e => e.situacao)
                .HasColumnType("int");

            builder.Property(e => e.xml)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.excluido)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.identificador_microvix)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.dt_insert)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.nProtCanc)
                .HasColumnType("varchar(15)");

            builder.Property(e => e.nProtInut)
                .HasColumnType("varchar(15)");

            builder.Property(e => e.xmlDistribuicao)
                .HasColumnType("varchar(max)");

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
