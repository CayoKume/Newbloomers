using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxClientesRedeMap : IEntityTypeConfiguration<LinxClientesRede>
    {
        public void Configure(EntityTypeBuilder<LinxClientesRede> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxClientesRede));

            builder.ToTable("LinxClientesRede");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_clientes_rede);
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

            builder.Property(e => e.id_clientes_rede)
                .HasColumnType("int");

            builder.Property(e => e.doc_cliente)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.nome_razao_social)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.data_cadastro)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.pf_pj)
                .HasColumnType("char(1)");

            builder.Property(e => e.tipo)
                .HasColumnType("char(1)");

            builder.Property(e => e.endereco)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.cidade)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.uf)
                .HasColumnType("varchar(2)");

            builder.Property(e => e.pais)
                .HasColumnType("varchar(80)");

            builder.Property(e => e.id_estado_civil)
                .HasColumnType("int");

            builder.Property(e => e.compras_a_prazo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.aceita_boleto_bancario)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.nome_fantasia)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.numero_endereco)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.complemento)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.bairro)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.cep)
                .HasColumnType("varchar(9)");

            builder.Property(e => e.telefone)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.celular)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.fax)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.email)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.site)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.data_nascimento)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.naturalidade)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.sexo)
                .HasColumnType("char(1)");

            builder.Property(e => e.nome_pai)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.nome_mae)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.identidade_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.data_emissao_identidade_cliente)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.uf_emissao_identidade_cliente)
                .HasColumnType("char(2)");

            builder.Property(e => e.orgao_emissao_identidade_cliente)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.observacao)
                .HasColumnType("varchar(500)");

            builder.Property(e => e.nome_empresa_titular)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.telefone_empresa_titular)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.funcao_titular)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.tempo_servico_titular)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.renda_titular)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.inscricao_estadual)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.inscricao_municipal)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.cliente_optante_simples_municipal)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.cliente_optante_simples_federal)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.limite_compras)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cartao_fidelidade)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.desabilitado)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.motivo_bloqueio)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.portal_origem)
                .HasColumnType("int");

            builder.Property(e => e.empresa_origem)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente_portal_origem)
                .HasColumnType("int");

            builder.Property(e => e.codigo_ws)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.integrado_ws)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
