using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxClientesRede
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_clientes_rede { get; private set; }

        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "doc_cliente")]
        public string? doc_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "nome_razao_social")]
        public string? nome_razao_social { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_cadastro { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "pf_pj")]
        public string? pf_pj { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "tipo")]
        public string? tipo { get; private set; }

        [Column(TypeName = "varchar(250)")]
        [LengthValidation(length: 250, propertyName: "endereco")]
        public string? endereco { get; private set; }
        
        [Column(TypeName = "varchar(40)")]
        [LengthValidation(length: 40, propertyName: "cidade")]
        public string? cidade { get; private set; }
        
        [Column(TypeName = "varchar(2)")]
        [LengthValidation(length: 2, propertyName: "uf")]
        public string? uf { get; private set; }
        
        [Column(TypeName = "varchar(80)")]
        [LengthValidation(length: 80, propertyName: "pais")]
        public string? pais { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_estado_civil { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? compras_a_prazo { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? aceita_boleto_bancario { get; private set; }
        
        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "nome_fantasia")]
        public string? nome_fantasia { get; private set; }
        
        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "numero_endereco")]
        public string? numero_endereco { get; private set; }
        
        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "complemento")]
        public string? complemento { get; private set; }
        
        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "bairro")]
        public string? bairro { get; private set; }
        
        [Column(TypeName = "varchar(9)")]
        [LengthValidation(length: 9, propertyName: "cep")]
        public string? cep { get; private set; }
        
        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "telefone")]
        public string? telefone { get; private set; }
        
        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "celular")]
        public string? celular { get; private set; }
        
        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "fax")]
        public string? fax { get; private set; }
        
        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "email")]
        public string? email { get; private set; }
        
        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "site")]
        public string? site { get; private set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? data_nascimento { get; private set; }
        
        [Column(TypeName = "varchar(40)")]
        [LengthValidation(length: 40, propertyName: "naturalidade")]
        public string? naturalidade { get; private set; }
        
        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "sexo")]
        public string? sexo { get; private set; }
        
        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "nome_pai")]
        public string? nome_pai { get; private set; }
        
        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "nome_mae")]
        public string? nome_mae { get; private set; }
        
        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "identidade_cliente")]
        public string? identidade_cliente { get; private set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? data_emissao_identidade_cliente { get; private set; }
        
        [Column(TypeName = "char(2)")]
        [LengthValidation(length: 2, propertyName: "uf_emissao_identidade_cliente")]
        public string? uf_emissao_identidade_cliente { get; private set; }
        
        [Column(TypeName = "varchar(10)")]
        [LengthValidation(length: 10, propertyName: "orgao_emissao_identidade_cliente")]
        public string? orgao_emissao_identidade_cliente { get; private set; }
        
        [Column(TypeName = "varchar(500)")]
        [LengthValidation(length: 500, propertyName: "observacao")]
        public string? observacao { get; private set; }
        
        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "nome_empresa_titular")]
        public string? nome_empresa_titular { get; private set; }
        
        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "telefone_empresa_titular")]
        public string? telefone_empresa_titular { get; private set; }
        
        [Column(TypeName = "varchar(40)")]
        [LengthValidation(length: 40, propertyName: "funcao_titular")]
        public string? funcao_titular { get; private set; }
        
        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "tempo_servico_titular")]
        public string? tempo_servico_titular { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? renda_titular { get; private set; }
        
        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "inscricao_estadual")]
        public string? inscricao_estadual { get; private set; }
        
        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "inscricao_municipal")]
        public string? inscricao_municipal { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? cliente_optante_simples_municipal { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? cliente_optante_simples_federal { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? limite_compras { get; private set; }
        
        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "cartao_fidelidade")]
        public string? cartao_fidelidade { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? desabilitado { get; private set; }
        
        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "motivo_bloqueio")]
        public string? motivo_bloqueio { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? portal_origem { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? empresa_origem { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? cod_cliente_portal_origem { get; private set; }
        
        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "codigo_ws")]
        public string? codigo_ws { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? integrado_ws { get; private set; }
        
        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxClientesRede() { }

        public LinxClientesRede(
            List<ValidationResult> listValidations,
            string? id_clientes_rede,
            string? doc_cliente,
            string? nome_razao_social,
            string? data_cadastro,
            string? pf_pj,
            string? tipo,
            string? endereco,
            string? cidade,
            string? uf,
            string? pais,
            string? id_estado_civil,
            string? compras_a_prazo,
            string? aceita_boleto_bancario,
            string? nome_fantasia,
            string? numero_endereco,
            string? complemento,
            string? bairro,
            string? cep,
            string? telefone,
            string? celular,
            string? fax,
            string? email,
            string? site,
            string? data_nascimento,
            string? naturalidade,
            string? sexo,
            string? nome_pai,
            string? nome_mae,
            string? identidade_cliente,
            string? data_emissao_identidade_cliente,
            string? uf_emissao_identidade_cliente,
            string? orgao_emissao_identidade_cliente,
            string? observacao,
            string? nome_empresa_titular,
            string? telefone_empresa_titular,
            string? funcao_titular,
            string? tempo_servico_titular,
            string? renda_titular,
            string? inscricao_estadual,
            string? inscricao_municipal,
            string? cliente_optante_simples_municipal,
            string? cliente_optante_simples_federal,
            string? limite_compras,
            string? cartao_fidelidade,
            string? desabilitado,
            string? motivo_bloqueio,
            string? portal_origem,
            string? empresa_origem,
            string? cod_cliente_portal_origem,
            string? codigo_ws,
            string? integrado_ws,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_clientes_rede =
                ConvertToInt32Validation.IsValid(id_clientes_rede, "id_clientes_rede", listValidations) ?
                Convert.ToInt32(id_clientes_rede) :
                0;

            this.portal_origem =
                ConvertToInt32Validation.IsValid(portal_origem, "portal_origem", listValidations) ?
                Convert.ToInt32(portal_origem) :
                0;

            this.empresa_origem =
                ConvertToInt32Validation.IsValid(empresa_origem, "empresa_origem", listValidations) ?
                Convert.ToInt32(empresa_origem) :
                0;

            this.cod_cliente_portal_origem =
                ConvertToInt32Validation.IsValid(cod_cliente_portal_origem, "cod_cliente_portal_origem", listValidations) ?
                Convert.ToInt32(cod_cliente_portal_origem) :
                0;

            this.data_cadastro =
                ConvertToDateTimeValidation.IsValid(data_cadastro, "data_cadastro", listValidations) ?
                Convert.ToDateTime(data_cadastro) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_nascimento =
                ConvertToDateTimeValidation.IsValid(data_nascimento, "data_nascimento", listValidations) ?
                Convert.ToDateTime(data_nascimento) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_emissao_identidade_cliente =
                ConvertToDateTimeValidation.IsValid(data_emissao_identidade_cliente, "data_emissao_identidade_cliente", listValidations) ?
                Convert.ToDateTime(data_emissao_identidade_cliente) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.integrado_ws =
                ConvertToBooleanValidation.IsValid(integrado_ws, "integrado_ws", listValidations) ?
                Convert.ToBoolean(integrado_ws) :
                false;

            this.desabilitado =
                ConvertToBooleanValidation.IsValid(desabilitado, "desabilitado", listValidations) ?
                Convert.ToBoolean(desabilitado) :
                false;

            this.cliente_optante_simples_federal =
                ConvertToBooleanValidation.IsValid(cliente_optante_simples_federal, "cliente_optante_simples_federal", listValidations) ?
                Convert.ToBoolean(cliente_optante_simples_federal) :
                false;

            this.cliente_optante_simples_municipal =
                ConvertToBooleanValidation.IsValid(cliente_optante_simples_municipal, "cliente_optante_simples_municipal", listValidations) ?
                Convert.ToBoolean(cliente_optante_simples_municipal) :
                false;

            this.aceita_boleto_bancario =
                ConvertToBooleanValidation.IsValid(aceita_boleto_bancario, "aceita_boleto_bancario", listValidations) ?
                Convert.ToBoolean(aceita_boleto_bancario) :
                false;

            this.compras_a_prazo =
               ConvertToBooleanValidation.IsValid(compras_a_prazo, "compras_a_prazo", listValidations) ?
               Convert.ToBoolean(compras_a_prazo) :
               false;

            this.limite_compras =
                ConvertToDecimalValidation.IsValid(limite_compras, "limite_compras", listValidations) ?
                Convert.ToDecimal(limite_compras) :
                0;

            this.renda_titular =
                ConvertToDecimalValidation.IsValid(renda_titular, "renda_titular", listValidations) ?
                Convert.ToDecimal(renda_titular) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.doc_cliente = doc_cliente;
            this.nome_razao_social = nome_razao_social;
            this.pf_pj = pf_pj;
            this.tipo = tipo;
            this.endereco = endereco;
            this.cidade = cidade;
            this.uf = uf;
            this.pais = pais;
            this.nome_fantasia = nome_fantasia;
            this.numero_endereco = numero_endereco;
            this.complemento = complemento;
            this.bairro = bairro;
            this.cep = cep;
            this.telefone = telefone;
            this.celular = celular;
            this.fax = fax;
            this.email = email;
            this.site = site;
            this.naturalidade = naturalidade;
            this.sexo = sexo;
            this.nome_pai = nome_pai;
            this.nome_mae = nome_mae;
            this.identidade_cliente = identidade_cliente;
            this.uf_emissao_identidade_cliente = uf_emissao_identidade_cliente;
            this.orgao_emissao_identidade_cliente = orgao_emissao_identidade_cliente;
            this.observacao = observacao;
            this.nome_empresa_titular = nome_empresa_titular;
            this.telefone_empresa_titular = telefone_empresa_titular;
            this.funcao_titular = funcao_titular;
            this.tempo_servico_titular = tempo_servico_titular;
            this.inscricao_estadual = inscricao_estadual;
            this.inscricao_municipal = inscricao_municipal;
            this.cartao_fidelidade = cartao_fidelidade;
            this.motivo_bloqueio = motivo_bloqueio;
            this.codigo_ws = codigo_ws;
        }
    }
}
