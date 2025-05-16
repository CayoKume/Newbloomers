using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaNFeTrustedMap : IEntityTypeConfiguration<B2CConsultaNFe>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaNFe> builder)
        {
            builder.ToTable("B2CConsultaNFe", "linx_microvix_commerce");

            builder.HasKey(e => new { e.id_nfe, e.id_pedido, e.chave_nfe });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_nfe)
                .HasColumnType("int");

            builder.Property(e => e.id_pedido)
                .HasColumnType("int");

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.data_emissao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.chave_nfe)
                .HasColumnType("char(44)");

            builder.Property(e => e.situacao)
                .HasProviderColumnType(LogicalColumnType.TinyInt);

            builder.Property(e => e.xml)
                .HasColumnType("varchar(MAX)");

            builder.Property(e => e.excluido)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.identificador_microvix)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.dt_insert)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.valor_nota)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.serie)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.nProt)
                .HasColumnType("varchar(15)");

            builder.Property(e => e.codigo_modelo_nf)
                .HasColumnType("varchar(3)");

            builder.Property(e => e.justificativa)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.tpAmb)
                .HasColumnType("int");
        }
    }

    public class B2CConsultaNFeRawMap : IEntityTypeConfiguration<B2CConsultaNFe>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaNFe> builder)
        {
            builder.ToTable("B2CConsultaNFe", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_nfe)
                .HasColumnType("int");

            builder.Property(e => e.id_pedido)
                .HasColumnType("int");

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.data_emissao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.chave_nfe)
                .HasColumnType("char(44)");

            builder.Property(e => e.situacao)
                .HasProviderColumnType(LogicalColumnType.TinyInt);

            builder.Property(e => e.xml)
                .HasColumnType("varchar(MAX)");

            builder.Property(e => e.excluido)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.identificador_microvix)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.dt_insert)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.valor_nota)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.serie)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.nProt)
                .HasColumnType("varchar(15)");

            builder.Property(e => e.codigo_modelo_nf)
                .HasColumnType("varchar(3)");

            builder.Property(e => e.justificativa)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.tpAmb)
                .HasColumnType("int");
        }
    }
}
