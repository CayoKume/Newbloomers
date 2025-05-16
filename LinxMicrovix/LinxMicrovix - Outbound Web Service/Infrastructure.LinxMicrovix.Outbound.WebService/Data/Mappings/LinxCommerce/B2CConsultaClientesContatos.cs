using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaClientesContatosTrustedMap : IEntityTypeConfiguration<B2CConsultaClientesContatos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClientesContatos> builder)
        {
            builder.ToTable("B2CConsultaClientesContatos", "linx_microvix_commerce");

            builder.HasKey(e => new { e.id_clientes_contatos, e.id_contato_b2c, e.id_parentesco });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_clientes_contatos)
                .HasColumnType("int");

            builder.Property(e => e.id_contato_b2c)
                .HasColumnType("int");

            builder.Property(e => e.nome_contato)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.data_nasc_contato)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.sexo_contato)
                .HasColumnType("char(1)");

            builder.Property(e => e.id_parentesco)
                .HasColumnType("int");

            builder.Property(e => e.fone_contato)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.celular_contato)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.email_contato)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.cod_cliente_erp)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }

    public class B2CConsultaClientesContatosRawMap : IEntityTypeConfiguration<B2CConsultaClientesContatos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClientesContatos> builder)
        {
            builder.ToTable("B2CConsultaClientesContatos", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_clientes_contatos)
                .HasColumnType("int");

            builder.Property(e => e.id_contato_b2c)
                .HasColumnType("int");

            builder.Property(e => e.nome_contato)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.data_nasc_contato)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.sexo_contato)
                .HasColumnType("char(1)");

            builder.Property(e => e.id_parentesco)
                .HasColumnType("int");

            builder.Property(e => e.fone_contato)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.celular_contato)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.email_contato)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.cod_cliente_erp)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
