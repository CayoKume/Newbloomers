using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxClientesFornecTrustedMap : IEntityTypeConfiguration<LinxClientesFornec>
    {
        public void Configure(EntityTypeBuilder<LinxClientesFornec> builder)
        {
            builder.ToTable("LinxClientesFornec", "linx_microvix_erp");

            builder.HasKey(e => new { e.cod_cliente, e.doc_cliente });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente)
                .HasColumnType("int");

            builder.Property(e => e.razao_cliente)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.nome_cliente)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.doc_cliente)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.tipo_cliente)
                .HasColumnType("char(1)");

            builder.Property(e => e.endereco_cliente)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.numero_rua_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.complement_end_cli)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.bairro_cliente)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.cep_cliente)
                .HasColumnType("char(9)");

            builder.Property(e => e.cidade_cliente)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.uf_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.pais)
                .HasColumnType("varchar(80)");

            builder.Property(e => e.fone_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.email_cliente)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.sexo)
                .HasColumnType("char(1)");

            builder.Property(e => e.data_cadastro)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.data_nascimento)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cel_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.ativo)
                .HasColumnType("char(1)");

            builder.Property(e => e.dt_update)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.inscricao_estadual)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.incricao_municipal)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.identidade_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.cartao_fidelidade)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.cod_ibge_municipio)
                .HasColumnType("int");

            builder.Property(e => e.classe_cliente)
                .HasColumnType("varchar(83)");

            builder.Property(e => e.matricula_conveniado)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.tipo_cadastro)
                .HasColumnType("char(1)");

            builder.Property(e => e.empresa_cadastro)
                .HasColumnType("int");

            builder.Property(e => e.id_estado_civil)
                .HasColumnType("int");

            builder.Property(e => e.fax_cliente)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.site_cliente)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.cliente_anonimo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.limite_compras)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.codigo_ws)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.limite_credito_compra)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_classe_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.obs)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.mae)
                .HasColumnType("varchar(60)");
        }
    }

    public class LinxClientesFornecRawMap : IEntityTypeConfiguration<LinxClientesFornec>
    {
        public void Configure(EntityTypeBuilder<LinxClientesFornec> builder)
        {
            builder.ToTable("LinxClientesFornec", "untreated");

        builder.HasKey(e => new { e.cod_cliente, e.doc_cliente });

        builder.Property(e => e.lastupdateon)
            .HasProviderColumnType(LogicalColumnType.DateTime);

        builder.Property(e => e.portal)
            .HasColumnType("int");

        builder.Property(e => e.cod_cliente)
            .HasColumnType("int");

        builder.Property(e => e.razao_cliente)
            .HasColumnType("varchar(60)");

        builder.Property(e => e.nome_cliente)
            .HasColumnType("varchar(60)");

        builder.Property(e => e.doc_cliente)
            .HasColumnType("varchar(14)");

        builder.Property(e => e.tipo_cliente)
            .HasColumnType("char(1)");

        builder.Property(e => e.endereco_cliente)
            .HasColumnType("varchar(250)");

        builder.Property(e => e.numero_rua_cliente)
            .HasColumnType("varchar(20)");

        builder.Property(e => e.complement_end_cli)
            .HasColumnType("varchar(60)");

        builder.Property(e => e.bairro_cliente)
            .HasColumnType("varchar(60)");

        builder.Property(e => e.cep_cliente)
            .HasColumnType("char(9)");

        builder.Property(e => e.cidade_cliente)
            .HasColumnType("varchar(40)");

        builder.Property(e => e.uf_cliente)
            .HasColumnType("varchar(20)");

        builder.Property(e => e.pais)
            .HasColumnType("varchar(80)");

        builder.Property(e => e.fone_cliente)
            .HasColumnType("varchar(20)");

        builder.Property(e => e.email_cliente)
            .HasColumnType("varchar(50)");

        builder.Property(e => e.sexo)
            .HasColumnType("char(1)");

        builder.Property(e => e.data_cadastro)
            .HasProviderColumnType(LogicalColumnType.DateTime);

        builder.Property(e => e.data_nascimento)
            .HasProviderColumnType(LogicalColumnType.DateTime);

        builder.Property(e => e.cel_cliente)
            .HasColumnType("varchar(20)");

        builder.Property(e => e.ativo)
            .HasColumnType("char(1)");

        builder.Property(e => e.dt_update)
            .HasProviderColumnType(LogicalColumnType.DateTime);

        builder.Property(e => e.inscricao_estadual)
            .HasColumnType("varchar(20)");

        builder.Property(e => e.incricao_municipal)
            .HasColumnType("varchar(20)");

        builder.Property(e => e.identidade_cliente)
            .HasColumnType("varchar(20)");

        builder.Property(e => e.cartao_fidelidade)
            .HasColumnType("varchar(20)");

        builder.Property(e => e.cod_ibge_municipio)
            .HasColumnType("int");

        builder.Property(e => e.classe_cliente)
            .HasColumnType("varchar(83)");

        builder.Property(e => e.matricula_conveniado)
            .HasColumnType("varchar(20)");

        builder.Property(e => e.tipo_cadastro)
            .HasColumnType("char(1)");

        builder.Property(e => e.empresa_cadastro)
            .HasColumnType("int");

        builder.Property(e => e.id_estado_civil)
            .HasColumnType("int");

        builder.Property(e => e.fax_cliente)
            .HasColumnType("varchar(50)");

        builder.Property(e => e.site_cliente)
            .HasColumnType("varchar(50)");

        builder.Property(e => e.timestamp)
            .HasColumnType("bigint");

        builder.Property(e => e.cliente_anonimo)
            .HasProviderColumnType(LogicalColumnType.Bool);

        builder.Property(e => e.limite_compras)
            .HasColumnType("decimal(10,2)");

        builder.Property(e => e.codigo_ws)
            .HasColumnType("varchar(100)");

        builder.Property(e => e.limite_credito_compra)
            .HasColumnType("decimal(10,2)");

        builder.Property(e => e.id_classe_fiscal)
            .HasColumnType("int");

        builder.Property(e => e.obs)
            .HasColumnType("varchar(max)");

        builder.Property(e => e.mae)
            .HasColumnType("varchar(60)");
        }
    }
}
