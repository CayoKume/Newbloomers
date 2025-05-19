using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Migrations
{
    /// <inheritdoc />
    public partial class initpostgresql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "linx_microvix_commerce");

            migrationBuilder.EnsureSchema(
                name: "linx_microvix_erp");

            migrationBuilder.CreateTable(
                name: "B2CConsultaClientes",
                schema: "linx_microvix_commerce",
                columns: table => new
                {
                    cod_cliente_b2c = table.Column<int>(type: "int", nullable: false),
                    cod_cliente_erp = table.Column<int>(type: "int", nullable: false),
                    doc_cliente = table.Column<string>(type: "varchar(14)", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    nm_cliente = table.Column<string>(type: "varchar(60)", nullable: true),
                    nm_mae = table.Column<string>(type: "varchar(50)", nullable: true),
                    nm_pai = table.Column<string>(type: "varchar(50)", nullable: true),
                    nm_conjuge = table.Column<string>(type: "varchar(50)", nullable: true),
                    dt_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    dt_nasc_cliente = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    end_cliente = table.Column<string>(type: "varchar(250)", nullable: true),
                    complemento_end_cliente = table.Column<string>(type: "varchar(50)", nullable: true),
                    nr_rua_cliente = table.Column<string>(type: "varchar(20)", nullable: true),
                    bairro_cliente = table.Column<string>(type: "varchar(60)", nullable: true),
                    cep_cliente = table.Column<string>(type: "varchar(9)", nullable: true),
                    cidade_cliente = table.Column<string>(type: "varchar(40)", nullable: true),
                    uf_cliente = table.Column<string>(type: "char(2)", nullable: true),
                    fone_cliente = table.Column<string>(type: "varchar(20)", nullable: true),
                    fone_comercial = table.Column<string>(type: "varchar(20)", nullable: true),
                    cel_cliente = table.Column<string>(type: "varchar(20)", nullable: true),
                    email_cliente = table.Column<string>(type: "varchar(50)", nullable: true),
                    rg_cliente = table.Column<string>(type: "varchar(20)", nullable: true),
                    rg_orgao_emissor = table.Column<string>(type: "varchar(7)", nullable: true),
                    estado_civil_cliente = table.Column<int>(type: "integer", nullable: true),
                    empresa_cliente = table.Column<string>(type: "varchar(30)", nullable: true),
                    cargo_cliente = table.Column<string>(type: "varchar(30)", nullable: true),
                    sexo_cliente = table.Column<string>(type: "char(1)", nullable: true),
                    dt_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ativo = table.Column<int>(type: "integer", nullable: true),
                    receber_email = table.Column<bool>(type: "boolean", nullable: true),
                    dt_expedicao_rg = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    naturalidade = table.Column<string>(type: "varchar(40)", nullable: true),
                    tempo_residencia = table.Column<int>(type: "integer", nullable: true),
                    renda = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    numero_compl_rua_cliente = table.Column<string>(type: "varchar(10)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    tipo_pessoa = table.Column<string>(type: "char(1)", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    aceita_programa_fidelidade = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2CConsultaClientes", x => new { x.cod_cliente_b2c, x.cod_cliente_erp, x.doc_cliente });
                });

            migrationBuilder.CreateTable(
                name: "B2CConsultaClientesEnderecosEntrega",
                schema: "linx_microvix_commerce",
                columns: table => new
                {
                    id_endereco_entrega = table.Column<int>(type: "int", nullable: false),
                    cod_cliente_erp = table.Column<int>(type: "int", nullable: false),
                    cod_cliente_b2c = table.Column<int>(type: "int", nullable: false),
                    id_cidade = table.Column<int>(type: "int", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    endereco_cliente = table.Column<string>(type: "varchar(250)", nullable: true),
                    numero_rua_cliente = table.Column<string>(type: "varchar(20)", nullable: true),
                    complemento_end_cli = table.Column<string>(type: "varchar(60)", nullable: true),
                    cep_cliente = table.Column<string>(type: "char(9)", nullable: true),
                    bairro_cliente = table.Column<string>(type: "varchar(60)", nullable: true),
                    cidade_cliente = table.Column<string>(type: "varchar(40)", nullable: true),
                    uf_cliente = table.Column<string>(type: "char(2)", nullable: true),
                    descricao = table.Column<string>(type: "varchar(250)", nullable: true),
                    principal = table.Column<bool>(type: "boolean", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2CConsultaClientesEnderecosEntrega", x => new { x.id_endereco_entrega, x.cod_cliente_erp, x.cod_cliente_b2c, x.id_cidade });
                });

            migrationBuilder.CreateTable(
                name: "B2CConsultaEmpresas",
                schema: "linx_microvix_commerce",
                columns: table => new
                {
                    empresa = table.Column<int>(type: "int", nullable: false),
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    nome_emp = table.Column<string>(type: "varchar(50)", nullable: true),
                    end_unidade = table.Column<string>(type: "varchar(250)", nullable: true),
                    complemento_end_unidade = table.Column<string>(type: "varchar(60)", nullable: true),
                    nr_rua_unidade = table.Column<string>(type: "varchar(20)", nullable: true),
                    bairro_unidade = table.Column<string>(type: "varchar(60)", nullable: true),
                    cep_unidade = table.Column<string>(type: "varchar(9)", nullable: true),
                    cidade_unidade = table.Column<string>(type: "varchar(50)", nullable: true),
                    uf_unidade = table.Column<string>(type: "char(2)", nullable: true),
                    email_unidade = table.Column<string>(type: "varchar(50)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    centro_distribuicao = table.Column<bool>(type: "boolean", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2CConsultaEmpresas", x => new { x.empresa, x.cnpj_emp });
                });

            migrationBuilder.CreateTable(
                name: "B2CConsultaNFe",
                schema: "linx_microvix_commerce",
                columns: table => new
                {
                    id_nfe = table.Column<int>(type: "int", nullable: false),
                    id_pedido = table.Column<int>(type: "int", nullable: false),
                    chave_nfe = table.Column<string>(type: "char(44)", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    documento = table.Column<int>(type: "int", nullable: true),
                    data_emissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    situacao = table.Column<int>(type: "integer", nullable: true),
                    xml = table.Column<string>(type: "text", nullable: true),
                    excluido = table.Column<bool>(type: "boolean", nullable: true),
                    identificador_microvix = table.Column<Guid>(type: "uuid", nullable: true),
                    dt_insert = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    valor_nota = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    serie = table.Column<string>(type: "varchar(10)", nullable: true),
                    frete = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    nProt = table.Column<string>(type: "varchar(15)", nullable: true),
                    codigo_modelo_nf = table.Column<string>(type: "varchar(3)", nullable: true),
                    justificativa = table.Column<string>(type: "varchar(255)", nullable: true),
                    tpAmb = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2CConsultaNFe", x => new { x.id_nfe, x.id_pedido, x.chave_nfe });
                });

            migrationBuilder.CreateTable(
                name: "B2CConsultaNFeSituacao",
                schema: "linx_microvix_commerce",
                columns: table => new
                {
                    id_nfe_situacao = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    descricao = table.Column<string>(type: "varchar(30)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2CConsultaNFeSituacao", x => x.id_nfe_situacao);
                });

            migrationBuilder.CreateTable(
                name: "B2CConsultaPedidos",
                schema: "linx_microvix_commerce",
                columns: table => new
                {
                    id_pedido = table.Column<int>(type: "int", nullable: false),
                    cod_cliente_erp = table.Column<int>(type: "int", nullable: false),
                    cod_cliente_b2c = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<string>(type: "varchar(40)", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    dt_pedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    vl_frete = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    forma_pgto = table.Column<int>(type: "int", nullable: true),
                    plano_pagamento = table.Column<int>(type: "int", nullable: true),
                    anotacao = table.Column<string>(type: "varchar(400)", nullable: true),
                    taxa_impressao = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    finalizado = table.Column<int>(type: "integer", nullable: true),
                    valor_frete_gratis = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    tipo_frete = table.Column<int>(type: "int", nullable: true),
                    id_status = table.Column<int>(type: "int", nullable: true),
                    cod_transportador = table.Column<int>(type: "int", nullable: true),
                    tipo_cobranca_frete = table.Column<int>(type: "int", nullable: true),
                    ativo = table.Column<int>(type: "integer", nullable: true),
                    empresa = table.Column<int>(type: "int", nullable: true),
                    id_tabela_preco = table.Column<int>(type: "int", nullable: true),
                    valor_credito = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    cod_vendedor = table.Column<int>(type: "int", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    dt_insert = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    dt_disponivel_faturamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    mensagem_falha_faturamento = table.Column<string>(type: "text", nullable: true),
                    id_tipo_b2c = table.Column<int>(type: "integer", nullable: true),
                    ecommerce_origem = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2CConsultaPedidos", x => new { x.id_pedido, x.cod_cliente_erp, x.cod_cliente_b2c, x.order_id });
                });

            migrationBuilder.CreateTable(
                name: "B2CConsultaPedidosIdentificador",
                schema: "linx_microvix_commerce",
                columns: table => new
                {
                    identificador = table.Column<Guid>(type: "uuid", nullable: false),
                    id_venda = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<string>(type: "varchar(40)", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    empresa = table.Column<int>(type: "int", nullable: true),
                    valor_frete = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    data_origem = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2CConsultaPedidosIdentificador", x => new { x.identificador, x.id_venda, x.order_id, x.id_cliente });
                });

            migrationBuilder.CreateTable(
                name: "B2CConsultaPedidosItens",
                schema: "linx_microvix_commerce",
                columns: table => new
                {
                    id_pedido_item = table.Column<int>(type: "int", nullable: false),
                    id_pedido = table.Column<int>(type: "int", nullable: false),
                    codigoproduto = table.Column<long>(type: "bigint", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    quantidade = table.Column<int>(type: "int", nullable: true),
                    vl_unitario = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2CConsultaPedidosItens", x => new { x.id_pedido_item, x.id_pedido, x.codigoproduto });
                });

            migrationBuilder.CreateTable(
                name: "B2CConsultaPedidosStatus",
                schema: "linx_microvix_commerce",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_pedido = table.Column<int>(type: "int", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    id_status = table.Column<int>(type: "integer", nullable: true),
                    data_hora = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    anotacao = table.Column<string>(type: "varchar(80)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2CConsultaPedidosStatus", x => new { x.id, x.id_pedido });
                });

            migrationBuilder.CreateTable(
                name: "B2CConsultaStatus",
                schema: "linx_microvix_commerce",
                columns: table => new
                {
                    id_status = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    descricao_status = table.Column<string>(type: "varchar(30)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2CConsultaStatus", x => x.id_status);
                });

            migrationBuilder.CreateTable(
                name: "LinxB2CPedidos",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    id_pedido = table.Column<int>(type: "int", nullable: false),
                    cod_cliente_erp = table.Column<int>(type: "int", nullable: false),
                    cod_cliente_b2c = table.Column<int>(type: "int", nullable: false),
                    empresa = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<string>(type: "varchar(40)", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_pedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vl_frete = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    forma_pgto = table.Column<int>(type: "int", nullable: false),
                    plano_pagamento = table.Column<int>(type: "int", nullable: false),
                    anotacao = table.Column<string>(type: "varchar(400)", nullable: false),
                    taxa_impressao = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    finalizado = table.Column<bool>(type: "boolean", nullable: false),
                    valor_frete_gratis = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    tipo_frete = table.Column<int>(type: "int", nullable: false),
                    id_status = table.Column<int>(type: "int", nullable: false),
                    cod_transportador = table.Column<int>(type: "int", nullable: false),
                    tipo_cobranca_frete = table.Column<int>(type: "int", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    id_tabela_preco = table.Column<int>(type: "int", nullable: false),
                    valor_credito = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    cod_vendedor = table.Column<int>(type: "int", nullable: false),
                    timestamp = table.Column<long>(type: "bigint", nullable: false),
                    dt_insert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_disponivel_faturamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    mensagem_falha_faturamento = table.Column<string>(type: "text", nullable: false),
                    portal = table.Column<int>(type: "int", nullable: false),
                    id_tipo_b2c = table.Column<int>(type: "int", nullable: false),
                    ecommerce_origem = table.Column<string>(type: "varchar(200)", nullable: false),
                    marketplace_loja = table.Column<string>(type: "varchar(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxB2CPedidos", x => new { x.id_pedido, x.cod_cliente_erp, x.cod_cliente_b2c, x.empresa, x.order_id });
                });

            migrationBuilder.CreateTable(
                name: "LinxB2CPedidosItens",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    id_pedido_item = table.Column<int>(type: "int", nullable: false),
                    id_pedido = table.Column<int>(type: "int", nullable: false),
                    codigoproduto = table.Column<long>(type: "bigint", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    vl_unitario = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    timestamp = table.Column<long>(type: "bigint", nullable: false),
                    portal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxB2CPedidosItens", x => new { x.id_pedido_item, x.id_pedido, x.codigoproduto });
                });

            migrationBuilder.CreateTable(
                name: "LinxB2CPedidosStatus",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    id_status = table.Column<int>(type: "int", nullable: true),
                    id_pedido = table.Column<int>(type: "int", nullable: true),
                    data_hora = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    anotacao = table.Column<string>(type: "varchar(80)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxB2CPedidosStatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LinxB2CStatus",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    id_status = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    descricao_status = table.Column<string>(type: "varchar(30)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxB2CStatus", x => x.id_status);
                });

            migrationBuilder.CreateTable(
                name: "LinxCfopFiscal",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    id_cfop_fiscal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: false),
                    cfop_fiscal = table.Column<string>(type: "varchar(5)", nullable: true),
                    descricao = table.Column<string>(type: "varchar(300)", nullable: true),
                    excluido = table.Column<bool>(type: "boolean", nullable: false),
                    timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxCfopFiscal", x => x.id_cfop_fiscal);
                });

            migrationBuilder.CreateTable(
                name: "LinxClientesEnderecosEntrega",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    id_endereco_entrega = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cod_cliente = table.Column<int>(type: "int", nullable: true),
                    endereco_cliente = table.Column<string>(type: "varchar(250)", nullable: true),
                    numero_rua_cliente = table.Column<string>(type: "varchar(20)", nullable: true),
                    complemento_end_cli = table.Column<string>(type: "varchar(60)", nullable: true),
                    cep_cliente = table.Column<string>(type: "char(9)", nullable: true),
                    bairro_cliente = table.Column<string>(type: "varchar(60)", nullable: true),
                    cidade_cliente = table.Column<string>(type: "varchar(40)", nullable: true),
                    uf_cliente = table.Column<string>(type: "char(2)", nullable: true),
                    descricao = table.Column<string>(type: "varchar(250)", nullable: true),
                    principal = table.Column<bool>(type: "boolean", nullable: true),
                    fone_cliente = table.Column<string>(type: "varchar(20)", nullable: true),
                    fone_celular = table.Column<string>(type: "varchar(20)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxClientesEnderecosEntrega", x => x.id_endereco_entrega);
                });

            migrationBuilder.CreateTable(
                name: "LinxClientesFornec",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cod_cliente = table.Column<int>(type: "int", nullable: false),
                    doc_cliente = table.Column<string>(type: "varchar(14)", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    razao_cliente = table.Column<string>(type: "varchar(60)", nullable: true),
                    nome_cliente = table.Column<string>(type: "varchar(60)", nullable: true),
                    tipo_cliente = table.Column<string>(type: "char(1)", nullable: true),
                    endereco_cliente = table.Column<string>(type: "varchar(250)", nullable: true),
                    numero_rua_cliente = table.Column<string>(type: "varchar(20)", nullable: true),
                    complement_end_cli = table.Column<string>(type: "varchar(60)", nullable: true),
                    bairro_cliente = table.Column<string>(type: "varchar(60)", nullable: true),
                    cep_cliente = table.Column<string>(type: "char(9)", nullable: true),
                    cidade_cliente = table.Column<string>(type: "varchar(40)", nullable: true),
                    uf_cliente = table.Column<string>(type: "varchar(20)", nullable: true),
                    pais = table.Column<string>(type: "varchar(80)", nullable: true),
                    fone_cliente = table.Column<string>(type: "varchar(20)", nullable: true),
                    email_cliente = table.Column<string>(type: "varchar(50)", nullable: true),
                    sexo = table.Column<string>(type: "char(1)", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_nascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cel_cliente = table.Column<string>(type: "varchar(20)", nullable: true),
                    ativo = table.Column<string>(type: "char(1)", nullable: true),
                    dt_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    inscricao_estadual = table.Column<string>(type: "varchar(20)", nullable: true),
                    incricao_municipal = table.Column<string>(type: "varchar(20)", nullable: true),
                    identidade_cliente = table.Column<string>(type: "varchar(20)", nullable: true),
                    cartao_fidelidade = table.Column<string>(type: "varchar(20)", nullable: true),
                    cod_ibge_municipio = table.Column<int>(type: "int", nullable: true),
                    classe_cliente = table.Column<string>(type: "varchar(83)", nullable: true),
                    matricula_conveniado = table.Column<string>(type: "varchar(20)", nullable: true),
                    tipo_cadastro = table.Column<string>(type: "char(1)", nullable: true),
                    empresa_cadastro = table.Column<int>(type: "int", nullable: true),
                    id_estado_civil = table.Column<int>(type: "int", nullable: true),
                    fax_cliente = table.Column<string>(type: "varchar(50)", nullable: true),
                    site_cliente = table.Column<string>(type: "varchar(50)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    cliente_anonimo = table.Column<bool>(type: "boolean", nullable: true),
                    limite_compras = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    codigo_ws = table.Column<string>(type: "varchar(100)", nullable: true),
                    limite_credito_compra = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    id_classe_fiscal = table.Column<int>(type: "int", nullable: true),
                    obs = table.Column<string>(type: "text", nullable: true),
                    mae = table.Column<string>(type: "varchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxClientesFornec", x => new { x.cod_cliente, x.doc_cliente });
                });

            migrationBuilder.CreateTable(
                name: "LinxGrupoLojas",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    id_empresas_rede = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cnpj = table.Column<string>(type: "varchar(14)", nullable: true),
                    nome_empresa = table.Column<string>(type: "varchar(50)", nullable: true),
                    rede = table.Column<string>(type: "varchar(100)", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    nome_portal = table.Column<string>(type: "varchar(50)", nullable: true),
                    empresa = table.Column<int>(type: "int", nullable: true),
                    classificacao_portal = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxGrupoLojas", x => x.id_empresas_rede);
                });

            migrationBuilder.CreateTable(
                name: "LinxLojas",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    empresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    nome_emp = table.Column<string>(type: "varchar(50)", nullable: true),
                    razao_emp = table.Column<string>(type: "varchar(200)", nullable: true),
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: true),
                    inscricao_emp = table.Column<string>(type: "varchar(20)", nullable: true),
                    endereco_emp = table.Column<string>(type: "varchar(250)", nullable: true),
                    num_emp = table.Column<int>(type: "int", nullable: true),
                    complement_emp = table.Column<string>(type: "varchar(60)", nullable: true),
                    bairro_emp = table.Column<string>(type: "varchar(50)", nullable: true),
                    cep_emp = table.Column<string>(type: "char(9)", nullable: true),
                    cidade_emp = table.Column<string>(type: "varchar(50)", nullable: true),
                    estado_emp = table.Column<string>(type: "char(2)", nullable: true),
                    fone_emp = table.Column<string>(type: "varchar(70)", nullable: true),
                    email_emp = table.Column<string>(type: "varchar(50)", nullable: true),
                    cod_ibge_municipio = table.Column<int>(type: "int", nullable: true),
                    data_criacao_emp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_criacao_portal = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    sistema_tributacao = table.Column<string>(type: "char(1)", nullable: true),
                    regime_tributario = table.Column<int>(type: "int", nullable: true),
                    area_empresa = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    timestamp = table.Column<int>(type: "int", nullable: true),
                    sigla_empresa = table.Column<string>(type: "varchar(10)", nullable: true),
                    id_classe_fiscal = table.Column<int>(type: "int", nullable: true),
                    centro_distribuicao = table.Column<bool>(type: "boolean", nullable: true),
                    inscricao_municipal_emp = table.Column<string>(type: "varchar(30)", nullable: true),
                    cnae_emp = table.Column<string>(type: "varchar(7)", nullable: true),
                    cod_cliente_linx = table.Column<string>(type: "varchar(6)", nullable: true),
                    tabela_preco_preferencial = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxLojas", x => x.empresa);
                });

            migrationBuilder.CreateTable(
                name: "LinxMovimento",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: false),
                    documento = table.Column<int>(type: "int", nullable: false),
                    chave_nf = table.Column<string>(type: "varchar(44)", nullable: false),
                    data_documento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    codigo_cliente = table.Column<int>(type: "int", nullable: false),
                    cod_produto = table.Column<long>(type: "bigint", nullable: false),
                    cancelado = table.Column<string>(type: "char(1)", nullable: false),
                    excluido = table.Column<string>(type: "char(1)", nullable: false),
                    transacao_pedido_venda = table.Column<int>(type: "int", nullable: false),
                    ordem = table.Column<int>(type: "int", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    transacao = table.Column<int>(type: "int", nullable: true),
                    usuario = table.Column<int>(type: "int", nullable: true),
                    ecf = table.Column<int>(type: "int", nullable: true),
                    numero_serie_ecf = table.Column<string>(type: "varchar(30)", nullable: true),
                    modelo_nf = table.Column<int>(type: "int", nullable: true),
                    data_lancamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    serie = table.Column<string>(type: "varchar(10)", nullable: true),
                    desc_cfop = table.Column<string>(type: "varchar(300)", nullable: true),
                    id_cfop = table.Column<string>(type: "varchar(5)", nullable: true),
                    cod_vendedor = table.Column<int>(type: "int", nullable: true),
                    quantidade = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    preco_custo = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    valor_liquido = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    desconto = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    cst_icms = table.Column<string>(type: "varchar(4)", nullable: true),
                    cst_pis = table.Column<string>(type: "varchar(4)", nullable: true),
                    cst_cofins = table.Column<string>(type: "varchar(4)", nullable: true),
                    cst_ipi = table.Column<string>(type: "varchar(4)", nullable: true),
                    valor_icms = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    aliquota_icms = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    base_icms = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    valor_pis = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    aliquota_pis = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    base_pis = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    valor_cofins = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    aliquota_cofins = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    base_cofins = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    valor_icms_st = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    aliquota_icms_st = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    base_icms_st = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    valor_ipi = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    aliquota_ipi = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    base_ipi = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    valor_total = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    forma_dinheiro = table.Column<int>(type: "integer", nullable: true),
                    total_dinheiro = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    forma_cheque = table.Column<int>(type: "integer", nullable: true),
                    total_cheque = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    forma_cartao = table.Column<int>(type: "integer", nullable: true),
                    total_cartao = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    forma_crediario = table.Column<int>(type: "integer", nullable: true),
                    total_crediario = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    forma_convenio = table.Column<int>(type: "integer", nullable: true),
                    total_convenio = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    frete = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    operacao = table.Column<string>(type: "char(2)", nullable: true),
                    tipo_transacao = table.Column<string>(type: "char(1)", nullable: true),
                    cod_barra = table.Column<string>(type: "varchar(20)", nullable: true),
                    soma_relatorio = table.Column<string>(type: "char(1)", nullable: true),
                    identificador = table.Column<Guid>(type: "uuid", nullable: true),
                    deposito = table.Column<string>(type: "varchar(100)", nullable: true),
                    obs = table.Column<string>(type: "text", nullable: true),
                    preco_unitario = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    hora_lancamento = table.Column<string>(type: "char(5)", nullable: true),
                    natureza_operacao = table.Column<string>(type: "varchar(60)", nullable: true),
                    tabela_preco = table.Column<int>(type: "int", nullable: true),
                    nome_tabela_preco = table.Column<string>(type: "varchar(50)", nullable: true),
                    cod_sefaz_situacao = table.Column<int>(type: "int", nullable: true),
                    desc_sefaz_situacao = table.Column<string>(type: "varchar(30)", nullable: true),
                    protocolo_aut_nfe = table.Column<string>(type: "varchar(15)", nullable: true),
                    dt_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    forma_cheque_prazo = table.Column<int>(type: "integer", nullable: true),
                    total_cheque_prazo = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    cod_natureza_operacao = table.Column<string>(type: "char(10)", nullable: true),
                    preco_tabela_epoca = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    desconto_total_item = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    conferido = table.Column<string>(type: "char(1)", nullable: true),
                    codigo_modelo_nf = table.Column<string>(type: "varchar(5)", nullable: true),
                    acrescimo = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    mob_checkout = table.Column<bool>(type: "boolean", nullable: true),
                    aliquota_iss = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    base_iss = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    codigo_rotina_origem = table.Column<int>(type: "int", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    troco = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    transportador = table.Column<int>(type: "int", nullable: true),
                    icms_aliquota_desonerado = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    icms_valor_desonerado_item = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    empresa = table.Column<int>(type: "int", nullable: true),
                    desconto_item = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    aliq_iss = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    iss_base_item = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    despesas = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    seguro_total_item = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    acrescimo_total_item = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    despesas_total_item = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    forma_pix = table.Column<int>(type: "integer", nullable: true),
                    total_pix = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    forma_deposito_bancario = table.Column<int>(type: "integer", nullable: true),
                    total_deposito_bancario = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    id_venda_produto_b2c = table.Column<int>(type: "int", nullable: true),
                    item_promocional = table.Column<bool>(type: "boolean", nullable: true),
                    acrescimo_item = table.Column<decimal>(type: "numeric", nullable: true),
                    icms_st_antecipado_aliquota = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    icms_st_antecipado_margem = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    icms_st_antecipado_percentual_reducao = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    icms_st_antecipado_valor_item = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    icms_base_desonerado_item = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    codigo_status_nfe = table.Column<string>(type: "varchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxMovimento", x => new { x.cnpj_emp, x.documento, x.chave_nf, x.data_documento, x.codigo_cliente, x.cod_produto, x.cancelado, x.excluido, x.transacao_pedido_venda, x.ordem });
                });

            migrationBuilder.CreateTable(
                name: "LinxMovimentoCartoes",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    identificador = table.Column<Guid>(type: "uuid", nullable: false),
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: false),
                    cupomfiscal = table.Column<string>(type: "varchar(20)", nullable: false),
                    cod_autorizacao = table.Column<string>(type: "varchar(50)", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    codlojasitef = table.Column<string>(type: "varchar(10)", nullable: true),
                    data_lancamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    credito_debito = table.Column<string>(type: "varchar(1)", nullable: true),
                    id_cartao_bandeira = table.Column<int>(type: "int", nullable: true),
                    descricao_bandeira = table.Column<string>(type: "varchar(100)", nullable: true),
                    valor = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    ordem_cartao = table.Column<int>(type: "int", nullable: true),
                    nsu_host = table.Column<string>(type: "varchar(50)", nullable: true),
                    nsu_sitef = table.Column<string>(type: "varchar(50)", nullable: true),
                    id_antecipacoes_financeiras = table.Column<int>(type: "int", nullable: true),
                    transacao_servico_terceiro = table.Column<bool>(type: "boolean", nullable: true),
                    texto_comprovante = table.Column<string>(type: "text", nullable: true),
                    id_maquineta_pos = table.Column<int>(type: "int", nullable: true),
                    descricao_maquineta = table.Column<string>(type: "varchar(50)", nullable: true),
                    serie_maquineta = table.Column<string>(type: "varchar(50)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    cartao_prepago = table.Column<string>(type: "varchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxMovimentoCartoes", x => new { x.identificador, x.cnpj_emp, x.cupomfiscal, x.cod_autorizacao });
                });

            migrationBuilder.CreateTable(
                name: "LinxMovimentoPlanos",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: false),
                    identificador = table.Column<Guid>(type: "uuid", nullable: false),
                    plano = table.Column<int>(type: "int", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    desc_plano = table.Column<string>(type: "varchar(35)", nullable: true),
                    total = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    qtde_parcelas = table.Column<int>(type: "int", nullable: true),
                    indice_plano = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    cod_forma_pgto = table.Column<int>(type: "int", nullable: true),
                    forma_pgto = table.Column<string>(type: "varchar(50)", nullable: true),
                    tipo_transacao = table.Column<string>(type: "char(1)", nullable: true),
                    taxa_financeira = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    ordem_cartao = table.Column<int>(type: "int", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    empresa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxMovimentoPlanos", x => new { x.cnpj_emp, x.identificador, x.plano });
                });

            migrationBuilder.CreateTable(
                name: "LinxMovimentoReshop",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    identificador = table.Column<Guid>(type: "uuid", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    id_movimento_campanha_reshop = table.Column<int>(type: "int", nullable: true),
                    id_campanha = table.Column<int>(type: "int", nullable: true),
                    nome = table.Column<string>(type: "varchar(200)", nullable: true),
                    descricao = table.Column<string>(type: "varchar(200)", nullable: true),
                    aplicar_desconto_venda = table.Column<bool>(type: "boolean", nullable: true),
                    valor_desconto_subtotal = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    valor_desconto_completo = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxMovimentoReshop", x => x.identificador);
                });

            migrationBuilder.CreateTable(
                name: "LinxMovimentoReshopItens",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    id_movimento_campanha_reshop_item = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    id_campanha = table.Column<int>(type: "int", nullable: true),
                    identificador = table.Column<Guid>(type: "uuid", nullable: true),
                    valor_unitario = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    valor_desconto_item = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    quantidade = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    valor_original = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    ordem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxMovimentoReshopItens", x => x.id_movimento_campanha_reshop_item);
                });

            migrationBuilder.CreateTable(
                name: "LinxMovimentoTrocas",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: false),
                    num_vale = table.Column<long>(type: "bigint", nullable: false),
                    doc_origem = table.Column<int>(type: "int", nullable: false),
                    doc_venda = table.Column<int>(type: "int", nullable: false),
                    doc_venda_origem = table.Column<int>(type: "int", nullable: false),
                    cod_cliente = table.Column<int>(type: "int", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    identificador = table.Column<Guid>(type: "uuid", nullable: true),
                    valor_vale = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    motivo = table.Column<string>(type: "varchar(50)", nullable: true),
                    serie_origem = table.Column<string>(type: "char(10)", nullable: true),
                    serie_venda = table.Column<string>(type: "char(10)", nullable: true),
                    excluido = table.Column<bool>(type: "boolean", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    desfazimento = table.Column<int>(type: "integer", nullable: true),
                    empresa = table.Column<int>(type: "int", nullable: true),
                    vale_cod_cliente = table.Column<int>(type: "int", nullable: true),
                    vale_codigoproduto = table.Column<long>(type: "bigint", nullable: true),
                    id_vale_ordem_servico_externa = table.Column<int>(type: "int", nullable: true),
                    serie_venda_origem = table.Column<string>(type: "char(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxMovimentoTrocas", x => new { x.cnpj_emp, x.num_vale, x.doc_origem, x.doc_venda, x.doc_venda_origem, x.cod_cliente });
                });

            migrationBuilder.CreateTable(
                name: "LinxNaturezaOperacao",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cod_natureza_operacao = table.Column<string>(type: "char(10)", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    descricao = table.Column<string>(type: "varchar(60)", nullable: true),
                    soma_relatorios = table.Column<string>(type: "char(1)", nullable: true),
                    operacao = table.Column<string>(type: "char(2)", nullable: true),
                    inativa = table.Column<string>(type: "char(1)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    calcula_ipi = table.Column<int>(type: "integer", nullable: true),
                    calcula_iss = table.Column<int>(type: "integer", nullable: true),
                    calcula_irrf = table.Column<int>(type: "integer", nullable: true),
                    tipo_preco = table.Column<string>(type: "char(2)", nullable: true),
                    atualiza_custo = table.Column<string>(type: "char(1)", nullable: true),
                    transferencia = table.Column<int>(type: "integer", nullable: true),
                    baixar_estoque = table.Column<int>(type: "integer", nullable: true),
                    consumo_proprio = table.Column<bool>(type: "boolean", nullable: true),
                    contabiliza_cmv = table.Column<bool>(type: "boolean", nullable: true),
                    despesa = table.Column<bool>(type: "boolean", nullable: true),
                    atualiza_custo_medio = table.Column<bool>(type: "boolean", nullable: true),
                    exige_nf_origem = table.Column<bool>(type: "boolean", nullable: true),
                    integra_contabilidade = table.Column<int>(type: "integer", nullable: true),
                    id_obs = table.Column<int>(type: "int", nullable: true),
                    venda_futura = table.Column<bool>(type: "boolean", nullable: true),
                    base_icms_considera_ipi = table.Column<bool>(type: "boolean", nullable: true),
                    permite_escolha_historico = table.Column<bool>(type: "boolean", nullable: true),
                    import_produtos = table.Column<bool>(type: "boolean", nullable: true),
                    deposito_reserva_venda = table.Column<int>(type: "int", nullable: true),
                    exibe_nfe = table.Column<bool>(type: "boolean", nullable: true),
                    faturamento_antecipado = table.Column<bool>(type: "boolean", nullable: true),
                    exibir_informacoes_imposto = table.Column<bool>(type: "boolean", nullable: true),
                    gera_garantia_nacional = table.Column<bool>(type: "boolean", nullable: true),
                    transferencia_deposito = table.Column<bool>(type: "boolean", nullable: true),
                    venda_diferencial_aliquota = table.Column<bool>(type: "boolean", nullable: true),
                    insere_obs_pis_cofins = table.Column<bool>(type: "boolean", nullable: true),
                    diferencial_ativo_consumo = table.Column<bool>(type: "boolean", nullable: true),
                    recusa_de = table.Column<bool>(type: "boolean", nullable: true),
                    codigo_ws = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxNaturezaOperacao", x => x.cod_natureza_operacao);
                });

            migrationBuilder.CreateTable(
                name: "LinxPedidosCompra",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: false),
                    cod_pedido = table.Column<int>(type: "int", nullable: false),
                    codigo_fornecedor = table.Column<int>(type: "int", nullable: false),
                    cod_produto = table.Column<long>(type: "bigint", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    data_pedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    transacao = table.Column<int>(type: "int", nullable: true),
                    usuario = table.Column<int>(type: "int", nullable: true),
                    quantidade = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    valor_unitario = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    cod_comprador = table.Column<int>(type: "int", nullable: true),
                    valor_frete = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    valor_total = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    cod_plano_pagamento = table.Column<int>(type: "int", nullable: true),
                    plano_pagamento = table.Column<string>(type: "varchar(35)", nullable: true),
                    obs = table.Column<string>(type: "text", nullable: true),
                    aprovado = table.Column<string>(type: "char(1)", nullable: true),
                    cancelado = table.Column<string>(type: "char(1)", nullable: true),
                    encerrado = table.Column<string>(type: "char(1)", nullable: true),
                    data_aprovacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    numero_ped_fornec = table.Column<string>(type: "varchar(15)", nullable: true),
                    tipo_frete = table.Column<string>(type: "char(1)", nullable: true),
                    natureza_operacao = table.Column<string>(type: "varchar(73)", nullable: true),
                    previsao_entrega = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    numero_projeto_officina = table.Column<string>(type: "varchar(50)", nullable: true),
                    status_pedido = table.Column<string>(type: "char(1)", nullable: true),
                    qtde_entregue = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    descricao_frete = table.Column<string>(type: "varchar(40)", nullable: true),
                    integrado_linx = table.Column<int>(type: "integer", nullable: true),
                    nf_gerada = table.Column<int>(type: "int", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    empresa = table.Column<int>(type: "int", nullable: true),
                    nf_origem_ws = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxPedidosCompra", x => new { x.cnpj_emp, x.cod_pedido, x.codigo_fornecedor, x.cod_produto });
                });

            migrationBuilder.CreateTable(
                name: "LinxPedidosVenda",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: false),
                    cod_pedido = table.Column<int>(type: "int", nullable: false),
                    codigo_cliente = table.Column<int>(type: "int", nullable: false),
                    cod_produto = table.Column<long>(type: "bigint", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    data_lancamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    hora_lancamento = table.Column<string>(type: "char(5)", nullable: true),
                    transacao = table.Column<int>(type: "int", nullable: true),
                    usuario = table.Column<int>(type: "int", nullable: true),
                    quantidade = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    valor_unitario = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    cod_vendedor = table.Column<int>(type: "int", nullable: true),
                    valor_frete = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    valor_total = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    desconto_item = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    cod_plano_pagamento = table.Column<int>(type: "int", nullable: true),
                    plano_pagamento = table.Column<string>(type: "varchar(35)", nullable: true),
                    obs = table.Column<string>(type: "text", nullable: true),
                    aprovado = table.Column<string>(type: "char(1)", nullable: true),
                    cancelado = table.Column<string>(type: "char(1)", nullable: true),
                    data_aprovacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    tipo_frete = table.Column<int>(type: "int", nullable: true),
                    natureza_operacao = table.Column<string>(type: "varchar(60)", nullable: true),
                    tabela_preco = table.Column<int>(type: "int", nullable: true),
                    nome_tabela_preco = table.Column<string>(type: "varchar(50)", nullable: true),
                    previsao_entrega = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    realizado_por = table.Column<int>(type: "int", nullable: true),
                    pontuacao_ser = table.Column<int>(type: "int", nullable: true),
                    venda_externa = table.Column<string>(type: "char(1)", nullable: true),
                    nf_gerada = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "char(1)", nullable: true),
                    numero_projeto_officina = table.Column<string>(type: "varchar(50)", nullable: true),
                    cod_natureza_operacao = table.Column<string>(type: "char(10)", nullable: true),
                    margem_contribuicao = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    doc_origem = table.Column<int>(type: "int", nullable: true),
                    posicao_item = table.Column<int>(type: "int", nullable: true),
                    orcamento_origem = table.Column<int>(type: "int", nullable: true),
                    transacao_origem = table.Column<int>(type: "int", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    desconto = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    transacao_ws = table.Column<int>(type: "int", nullable: true),
                    empresa = table.Column<int>(type: "int", nullable: true),
                    transportador = table.Column<long>(type: "bigint", nullable: true),
                    deposito = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxPedidosVenda", x => new { x.cnpj_emp, x.cod_pedido, x.codigo_cliente, x.cod_produto });
                });

            migrationBuilder.CreateTable(
                name: "LinxPlanos",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    plano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    desc_plano = table.Column<string>(type: "varchar(35)", nullable: true),
                    qtde_parcelas = table.Column<int>(type: "int", nullable: true),
                    prazo_entre_parcelas = table.Column<int>(type: "int", nullable: true),
                    tipo_plano = table.Column<string>(type: "char(1)", nullable: true),
                    indice_plano = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    cod_forma_pgto = table.Column<int>(type: "int", nullable: true),
                    forma_pgto = table.Column<string>(type: "varchar(50)", nullable: true),
                    conta_central = table.Column<int>(type: "int", nullable: true),
                    tipo_transacao = table.Column<string>(type: "char(1)", nullable: true),
                    taxa_financeira = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    dt_upd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    desativado = table.Column<string>(type: "char(1)", nullable: true),
                    usa_tef = table.Column<string>(type: "char(1)", nullable: true),
                    timestamp = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxPlanos", x => x.plano);
                });

            migrationBuilder.CreateTable(
                name: "LinxPlanosPedidoVenda",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cod_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: true),
                    plano = table.Column<int>(type: "int", nullable: true),
                    desc_plano = table.Column<string>(type: "varchar(35)", nullable: true),
                    total = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    qtde_parcelas = table.Column<int>(type: "int", nullable: true),
                    indice_plano = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    valor_desc_acresc_plano = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    cod_forma_pgto = table.Column<int>(type: "int", nullable: true),
                    forma_pgto = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxPlanosPedidoVenda", x => x.cod_pedido);
                });

            migrationBuilder.CreateTable(
                name: "LinxProdutos",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cod_produto = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    cod_barra = table.Column<string>(type: "varchar(20)", nullable: true),
                    nome = table.Column<string>(type: "varchar(250)", nullable: true),
                    ncm = table.Column<string>(type: "varchar(20)", nullable: true),
                    cest = table.Column<string>(type: "varchar(10)", nullable: true),
                    referencia = table.Column<string>(type: "varchar(20)", nullable: true),
                    cod_auxiliar = table.Column<string>(type: "varchar(40)", nullable: true),
                    unidade = table.Column<string>(type: "varchar(50)", nullable: true),
                    desc_cor = table.Column<string>(type: "varchar(30)", nullable: true),
                    desc_tamanho = table.Column<string>(type: "varchar(50)", nullable: true),
                    desc_setor = table.Column<string>(type: "varchar(30)", nullable: true),
                    desc_linha = table.Column<string>(type: "varchar(30)", nullable: true),
                    desc_marca = table.Column<string>(type: "varchar(30)", nullable: true),
                    desc_colecao = table.Column<string>(type: "varchar(50)", nullable: true),
                    dt_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cod_fornecedor = table.Column<int>(type: "int", nullable: true),
                    desativado = table.Column<string>(type: "char(10)", nullable: true),
                    desc_espessura = table.Column<string>(type: "varchar(50)", nullable: true),
                    id_espessura = table.Column<int>(type: "int", nullable: true),
                    desc_classificacao = table.Column<string>(type: "varchar(50)", nullable: true),
                    id_classificacao = table.Column<int>(type: "int", nullable: true),
                    origem_mercadoria = table.Column<int>(type: "int", nullable: true),
                    peso_liquido = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    peso_bruto = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    id_cor = table.Column<int>(type: "int", nullable: true),
                    id_tamanho = table.Column<string>(type: "varchar(5)", nullable: true),
                    id_setor = table.Column<int>(type: "int", nullable: true),
                    id_linha = table.Column<int>(type: "int", nullable: true),
                    id_marca = table.Column<int>(type: "int", nullable: true),
                    id_colecao = table.Column<int>(type: "int", nullable: true),
                    dt_inclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    fator_conversao = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    codigo_integracao_ws = table.Column<string>(type: "varchar(50)", nullable: true),
                    codigo_integracao_reshop = table.Column<string>(type: "varchar(50)", nullable: true),
                    id_produtos_opticos_tipo = table.Column<int>(type: "int", nullable: true),
                    id_sped_tipo_item = table.Column<int>(type: "int", nullable: true),
                    componente = table.Column<string>(type: "char(1)", nullable: true),
                    altura_para_frete = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    largura_para_frete = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    comprimento_para_frete = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    loja_virtual = table.Column<string>(type: "char(1)", nullable: true),
                    cod_comprador = table.Column<int>(type: "int", nullable: true),
                    obrigatorio_identificacao_cliente = table.Column<bool>(type: "boolean", nullable: true),
                    descricao_basica = table.Column<string>(type: "varchar(100)", nullable: true),
                    curva = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxProdutos", x => x.cod_produto);
                });

            migrationBuilder.CreateTable(
                name: "LinxProdutosCamposAdicionais",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cod_produto = table.Column<long>(type: "bigint", nullable: false),
                    campo = table.Column<string>(type: "varchar(30)", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    valor = table.Column<string>(type: "varchar(30)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxProdutosCamposAdicionais", x => new { x.cod_produto, x.campo });
                });

            migrationBuilder.CreateTable(
                name: "LinxProdutosCodBar",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cod_produto = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    cod_barra = table.Column<string>(type: "varchar(20)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxProdutosCodBar", x => x.cod_produto);
                });

            migrationBuilder.CreateTable(
                name: "LinxProdutosDepositos",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cod_deposito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    nome_deposito = table.Column<string>(type: "varchar(50)", nullable: true),
                    disponivel = table.Column<bool>(type: "boolean", nullable: true),
                    disponivel_transferencia = table.Column<bool>(type: "boolean", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxProdutosDepositos", x => x.cod_deposito);
                });

            migrationBuilder.CreateTable(
                name: "LinxProdutosDetalhes",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: false),
                    cod_produto = table.Column<int>(type: "int", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    cod_barra = table.Column<string>(type: "varchar(20)", nullable: true),
                    quantidade = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    preco_custo = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    preco_venda = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    custo_medio = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    id_config_tributaria = table.Column<int>(type: "int", nullable: true),
                    desc_config_tributaria = table.Column<string>(type: "varchar(100)", nullable: true),
                    despesas1 = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    qtde_minima = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    qtde_maxima = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    ipi = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    timestamp = table.Column<int>(type: "int", nullable: true),
                    empresa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxProdutosDetalhes", x => new { x.cnpj_emp, x.cod_produto });
                });

            migrationBuilder.CreateTable(
                name: "LinxProdutosDetalhesDepositos",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cod_produto = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: true),
                    empresa = table.Column<int>(type: "int", nullable: true),
                    cod_deposito = table.Column<int>(type: "int", nullable: true),
                    saldo = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxProdutosDetalhesDepositos", x => x.cod_produto);
                });

            migrationBuilder.CreateTable(
                name: "LinxProdutosInventario",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: false),
                    cod_produto = table.Column<long>(type: "bigint", nullable: false),
                    cod_deposito = table.Column<int>(type: "int", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    cod_barra = table.Column<string>(type: "varchar(20)", nullable: true),
                    quantidade = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    empresa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxProdutosInventario", x => new { x.cnpj_emp, x.cod_produto, x.cod_deposito });
                });

            migrationBuilder.CreateTable(
                name: "LinxProdutosPromocoes",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: false),
                    cod_produto = table.Column<long>(type: "bigint", nullable: false),
                    data_cadastro_promocao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    id_campanha = table.Column<long>(type: "bigint", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    preco_promocao = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    data_inicio_promocao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_termino_promocao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    promocao_ativa = table.Column<string>(type: "char(1)", nullable: true),
                    nome_campanha = table.Column<string>(type: "varchar(60)", nullable: true),
                    promocao_opcional = table.Column<bool>(type: "boolean", nullable: true),
                    custo_total_campanha = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxProdutosPromocoes", x => new { x.cnpj_emp, x.cod_produto, x.data_cadastro_promocao, x.id_campanha });
                });

            migrationBuilder.CreateTable(
                name: "LinxProdutosTabelas",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    id_tabela = table.Column<int>(type: "int", nullable: false),
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: false),
                    tipo_tabela = table.Column<string>(type: "char(1)", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    nome_tabela = table.Column<string>(type: "varchar(50)", nullable: true),
                    ativa = table.Column<string>(type: "char(1)", nullable: true),
                    timestamp = table.Column<int>(type: "int", nullable: true),
                    codigo_integracao_ws = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxProdutosTabelas", x => new { x.id_tabela, x.cnpj_emp, x.tipo_tabela });
                });

            migrationBuilder.CreateTable(
                name: "LinxProdutosTabelasPrecos",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cod_produto = table.Column<long>(type: "bigint", nullable: false),
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: false),
                    id_tabela = table.Column<int>(type: "int", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    precovenda = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxProdutosTabelasPrecos", x => new { x.cod_produto, x.cnpj_emp, x.id_tabela });
                });

            migrationBuilder.CreateTable(
                name: "LinxRotinaOrigem",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    codigo_rotina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    descricao_rotina = table.Column<string>(type: "varchar(150)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxRotinaOrigem", x => x.codigo_rotina);
                });

            migrationBuilder.CreateTable(
                name: "LinxSetores",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    id_setor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    desc_setor = table.Column<string>(type: "varchar(30)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    codigo_integracao_ws = table.Column<string>(type: "varchar(50)", nullable: true),
                    ativo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxSetores", x => x.id_setor);
                });

            migrationBuilder.CreateTable(
                name: "LinxUsuarios",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    usuario_login = table.Column<string>(type: "varchar(30)", nullable: true),
                    usuario_nome = table.Column<string>(type: "varchar(50)", nullable: true),
                    usuario_email = table.Column<string>(type: "varchar(60)", nullable: true),
                    usuario_grupo_id = table.Column<int>(type: "int", nullable: true),
                    grupo_usuarios = table.Column<string>(type: "char(1)", nullable: true),
                    usuario_supervisor = table.Column<string>(type: "char(1)", nullable: true),
                    usuario_doc = table.Column<string>(type: "varchar(14)", nullable: true),
                    vendedor = table.Column<int>(type: "int", nullable: true),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    desativado = table.Column<string>(type: "char(1)", nullable: true),
                    empresas = table.Column<string>(type: "text", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxUsuarios", x => x.usuario_id);
                });

            migrationBuilder.CreateTable(
                name: "LinxVendedores",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cod_vendedor = table.Column<int>(type: "int", nullable: false),
                    cpf_vendedor = table.Column<string>(type: "varchar(14)", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    nome_vendedor = table.Column<string>(type: "varchar(50)", nullable: true),
                    tipo_vendedor = table.Column<string>(type: "char(1)", nullable: true),
                    end_vend_rua = table.Column<string>(type: "varchar(250)", nullable: true),
                    end_vend_numero = table.Column<string>(type: "varchar(20)", nullable: true),
                    end_vend_complemento = table.Column<string>(type: "varchar(60)", nullable: true),
                    end_vend_bairro = table.Column<string>(type: "varchar(60)", nullable: true),
                    end_vend_cep = table.Column<string>(type: "varchar(9)", nullable: true),
                    end_vend_cidade = table.Column<string>(type: "varchar(40)", nullable: true),
                    end_vend_uf = table.Column<string>(type: "char(2)", nullable: true),
                    fone_vendedor = table.Column<string>(type: "varchar(20)", nullable: true),
                    mail_vendedor = table.Column<string>(type: "varchar(50)", nullable: true),
                    dt_upd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ativo = table.Column<string>(type: "char(1)", nullable: true),
                    data_admissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_saida = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    matricula = table.Column<string>(type: "varchar(30)", nullable: true),
                    id_tipo_venda = table.Column<int>(type: "int", nullable: true),
                    descricao_tipo_venda = table.Column<string>(type: "varchar(100)", nullable: true),
                    cargo = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxVendedores", x => new { x.cod_vendedor, x.cpf_vendedor });
                });

            migrationBuilder.CreateTable(
                name: "LinxXMLDocumentos",
                schema: "linx_microvix_erp",
                columns: table => new
                {
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: false),
                    documento = table.Column<int>(type: "int", nullable: false),
                    chave_nfe = table.Column<string>(type: "varchar(44)", nullable: false),
                    lastupdateon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    portal = table.Column<int>(type: "int", nullable: true),
                    serie = table.Column<string>(type: "varchar(10)", nullable: true),
                    data_emissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    situacao = table.Column<int>(type: "int", nullable: true),
                    xml = table.Column<string>(type: "text", nullable: true),
                    excluido = table.Column<bool>(type: "boolean", nullable: true),
                    identificador_microvix = table.Column<Guid>(type: "uuid", nullable: true),
                    dt_insert = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: true),
                    nProtCanc = table.Column<string>(type: "varchar(15)", nullable: true),
                    nProtInut = table.Column<string>(type: "varchar(15)", nullable: true),
                    xmlDistribuicao = table.Column<string>(type: "text", nullable: true),
                    nProtDeneg = table.Column<string>(type: "varchar(15)", nullable: true),
                    cStat = table.Column<string>(type: "varchar(5)", nullable: true),
                    id_nfe = table.Column<int>(type: "int", nullable: true),
                    cod_cliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinxXMLDocumentos", x => new { x.cnpj_emp, x.documento, x.chave_nfe });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "B2CConsultaClientes",
                schema: "linx_microvix_commerce");

            migrationBuilder.DropTable(
                name: "B2CConsultaClientesEnderecosEntrega",
                schema: "linx_microvix_commerce");

            migrationBuilder.DropTable(
                name: "B2CConsultaEmpresas",
                schema: "linx_microvix_commerce");

            migrationBuilder.DropTable(
                name: "B2CConsultaNFe",
                schema: "linx_microvix_commerce");

            migrationBuilder.DropTable(
                name: "B2CConsultaNFeSituacao",
                schema: "linx_microvix_commerce");

            migrationBuilder.DropTable(
                name: "B2CConsultaPedidos",
                schema: "linx_microvix_commerce");

            migrationBuilder.DropTable(
                name: "B2CConsultaPedidosIdentificador",
                schema: "linx_microvix_commerce");

            migrationBuilder.DropTable(
                name: "B2CConsultaPedidosItens",
                schema: "linx_microvix_commerce");

            migrationBuilder.DropTable(
                name: "B2CConsultaPedidosStatus",
                schema: "linx_microvix_commerce");

            migrationBuilder.DropTable(
                name: "B2CConsultaStatus",
                schema: "linx_microvix_commerce");

            migrationBuilder.DropTable(
                name: "LinxB2CPedidos",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxB2CPedidosItens",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxB2CPedidosStatus",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxB2CStatus",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxCfopFiscal",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxClientesEnderecosEntrega",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxClientesFornec",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxGrupoLojas",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxLojas",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxMovimento",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxMovimentoCartoes",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxMovimentoPlanos",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxMovimentoReshop",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxMovimentoReshopItens",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxMovimentoTrocas",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxNaturezaOperacao",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxPedidosCompra",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxPedidosVenda",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxPlanos",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxPlanosPedidoVenda",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxProdutos",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxProdutosCamposAdicionais",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxProdutosCodBar",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxProdutosDepositos",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxProdutosDetalhes",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxProdutosDetalhesDepositos",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxProdutosInventario",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxProdutosPromocoes",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxProdutosTabelas",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxProdutosTabelasPrecos",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxRotinaOrigem",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxSetores",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxUsuarios",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxVendedores",
                schema: "linx_microvix_erp");

            migrationBuilder.DropTable(
                name: "LinxXMLDocumentos",
                schema: "linx_microvix_erp");
        }
    }
}
