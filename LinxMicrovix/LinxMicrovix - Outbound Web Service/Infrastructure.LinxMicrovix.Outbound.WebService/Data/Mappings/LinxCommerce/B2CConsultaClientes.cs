using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaClientesTrustedMap : IEntityTypeConfiguration<B2CConsultaClientes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClientes> builder)
        {
            builder.ToTable("B2CConsultaClientes", "linx_microvix_commerce");

            builder.HasKey(e => new { e.cod_cliente_b2c, e.cod_cliente_erp, e.doc_cliente });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cod_cliente_b2c)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente_erp)
                .HasColumnType("int");

            builder.Property(e => e.doc_cliente)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.nm_cliente)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.nm_mae)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.nm_pai)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.nm_conjuge)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.dt_cadastro)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.dt_nasc_cliente)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.end_cliente)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.complemento_end_cliente)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.nr_rua_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.bairro_cliente)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.cep_cliente)
                .HasColumnType("varchar(9)");

            builder.Property(e => e.cidade_cliente)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.uf_cliente)
                .HasColumnType("char(2)");

            builder.Property(e => e.fone_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.fone_comercial)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.cel_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.email_cliente)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.rg_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.rg_orgao_emissor)
                .HasColumnType("varchar(7)");

            builder.Property(e => e.estado_civil_cliente)
                .HasProviderColumnType(LogicalColumnType.TinyInt);

            builder.Property(e => e.empresa_cliente)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.cargo_cliente)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.sexo_cliente)
                .HasColumnType("char(1)");

            builder.Property(e => e.dt_update)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.receber_email)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.dt_expedicao_rg)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.naturalidade)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.tempo_residencia)
                .HasProviderColumnType(LogicalColumnType.TinyInt);

            builder.Property(e => e.renda)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.numero_compl_rua_cliente)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.tipo_pessoa)
                .HasColumnType("char(1)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.aceita_programa_fidelidade)
                .HasProviderColumnType(LogicalColumnType.Bool);
        }
    }

    public class B2CConsultaClientesRawMap : IEntityTypeConfiguration<B2CConsultaClientes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClientes> builder)
        {
            builder.ToTable("B2CConsultaClientes", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cod_cliente_b2c)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente_erp)
                .HasColumnType("int");

            builder.Property(e => e.doc_cliente)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.nm_cliente)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.nm_mae)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.nm_pai)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.nm_conjuge)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.dt_cadastro)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.dt_nasc_cliente)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.end_cliente)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.complemento_end_cliente)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.nr_rua_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.bairro_cliente)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.cep_cliente)
                .HasColumnType("varchar(9)");

            builder.Property(e => e.cidade_cliente)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.uf_cliente)
                .HasColumnType("char(2)");

            builder.Property(e => e.fone_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.fone_comercial)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.cel_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.email_cliente)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.rg_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.rg_orgao_emissor)
                .HasColumnType("varchar(7)");

            builder.Property(e => e.estado_civil_cliente)
                .HasProviderColumnType(LogicalColumnType.TinyInt);

            builder.Property(e => e.empresa_cliente)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.cargo_cliente)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.sexo_cliente)
                .HasColumnType("char(1)");

            builder.Property(e => e.dt_update)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.receber_email)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.dt_expedicao_rg)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.naturalidade)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.tempo_residencia)
                .HasProviderColumnType(LogicalColumnType.TinyInt);

            builder.Property(e => e.renda)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.numero_compl_rua_cliente)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.tipo_pessoa)
                .HasColumnType("char(1)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.aceita_programa_fidelidade)
                .HasProviderColumnType(LogicalColumnType.Bool);
        }
    }
}
