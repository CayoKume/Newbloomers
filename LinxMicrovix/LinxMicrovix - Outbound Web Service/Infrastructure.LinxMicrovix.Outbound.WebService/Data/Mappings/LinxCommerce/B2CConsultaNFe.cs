using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaNFeMap : IEntityTypeConfiguration<B2CConsultaNFe>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaNFe> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaNFe));

            builder.ToTable("B2CConsultaNFe");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => new { e.id_nfe, e.id_pedido, e.chave_nfe });
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

            builder.Property(e => e.id_nfe)
                .HasColumnType("int");

            builder.Property(e => e.id_pedido)
                .HasColumnType("int");

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.data_emissao)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.chave_nfe)
                .HasColumnType("char(44)");

            builder.Property(e => e.situacao)
                .HasProviderColumnType(EnumTableColumnType.TinyInt);

            builder.Property(e => e.xml)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.excluido)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.identificador_microvix)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.dt_insert)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

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
