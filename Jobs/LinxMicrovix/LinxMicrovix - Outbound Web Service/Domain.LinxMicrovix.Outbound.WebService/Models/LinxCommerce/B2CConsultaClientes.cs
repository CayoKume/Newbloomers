using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaClientes
    {
        public DateTime? lastupdateon { get; private set; }
        public int? cod_cliente_b2c { get; private set; }
        public int? cod_cliente_erp { get; private set; }
        public string? doc_cliente { get; private set; }
        public string? nm_cliente { get; private set; }
        public string? nm_mae { get; private set; }
        public string? nm_pai { get; private set; }
        public string? nm_conjuge { get; private set; }
        public DateTime? dt_cadastro { get; private set; }
        public DateTime? dt_nasc_cliente { get; private set; }
        public string? end_cliente { get; private set; }
        public string? complemento_end_cliente { get; private set; }
        public string? nr_rua_cliente { get; private set; }
        public string? bairro_cliente { get; private set; }
        public string? cep_cliente { get; private set; }
        public string? cidade_cliente { get; private set; }
        public string? uf_cliente { get; private set; }
        public string? fone_cliente { get; private set; }
        public string? fone_comercial { get; private set; }
        public string? cel_cliente { get; private set; }
        public string? email_cliente { get; private set; }
        public string? rg_cliente { get; private set; }
        public string? rg_orgao_emissor { get; private set; }
        public Int32? estado_civil_cliente { get; private set; }
        public string? empresa_cliente { get; private set; }
        public string? cargo_cliente { get; private set; }
        public string? sexo_cliente { get; private set; }
        public DateTime? dt_update { get; private set; }
        public Int32? ativo { get; private set; }
        public bool? receber_email { get; private set; }
        public DateTime? dt_expedicao_rg { get; private set; }
        public string? naturalidade { get; private set; }
        public Int32? tempo_residencia { get; private set; }
        public decimal? renda { get; private set; }
        public string? numero_compl_rua_cliente { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? tipo_pessoa { get; private set; }
        public Int32? portal { get; private set; }
        public bool? aceita_programa_fidelidade { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaClientes() { }

        public B2CConsultaClientes(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaClientes cliente,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);

            this.cod_cliente_b2c = Convert.ToInt32(cliente.cod_cliente_b2c);
            this.cod_cliente_erp = CustomConvertersExtensions.ConvertToInt32Validation(cliente.cod_cliente_erp);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(cliente.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(cliente.timestamp);
            this.estado_civil_cliente = CustomConvertersExtensions.ConvertToInt32Validation(cliente.estado_civil_cliente);
            this.ativo = CustomConvertersExtensions.ConvertToInt32Validation(cliente.ativo);
            this.tempo_residencia = CustomConvertersExtensions.ConvertToInt32Validation(cliente.tempo_residencia);
            this.renda = CustomConvertersExtensions.ConvertToDecimalValidation(cliente.renda);
            this.receber_email = CustomConvertersExtensions.ConvertToBooleanValidation(cliente.receber_email);
            this.aceita_programa_fidelidade = CustomConvertersExtensions.ConvertToBooleanValidation(cliente.aceita_programa_fidelidade);
            this.dt_cadastro = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(cliente.dt_cadastro);
            this.dt_expedicao_rg = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(cliente.dt_expedicao_rg);
            this.dt_update = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(cliente.dt_update);
            this.dt_nasc_cliente = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(cliente.dt_nasc_cliente);

            //Refatorar Aqui (adicionar operador ternario para substring)
            this.doc_cliente = cliente.doc_cliente;
            this.nm_cliente = cliente.nm_cliente;
            this.nm_mae = cliente.nm_mae;
            this.nm_pai = cliente.nm_pai;
            this.nm_conjuge = cliente.nm_conjuge;
            this.end_cliente = cliente.end_cliente;
            this.complemento_end_cliente = cliente.complemento_end_cliente;
            this.nr_rua_cliente = cliente.nr_rua_cliente;
            this.bairro_cliente = cliente.bairro_cliente;
            this.cep_cliente = cliente.cep_cliente;
            this.cidade_cliente = cliente.cidade_cliente;
            this.uf_cliente = cliente.uf_cliente;
            this.fone_cliente = cliente.fone_cliente;
            this.fone_comercial = cliente.fone_comercial;
            this.cel_cliente = cliente.cel_cliente;
            this.email_cliente = cliente.email_cliente;
            this.rg_cliente = cliente.rg_cliente;
            this.rg_orgao_emissor = cliente.rg_orgao_emissor;
            this.empresa_cliente = cliente.empresa_cliente;
            this.cargo_cliente = cliente.cargo_cliente;
            this.sexo_cliente = cliente.sexo_cliente;
            this.naturalidade = cliente.naturalidade;
            this.numero_compl_rua_cliente = cliente.numero_compl_rua_cliente;
            this.tipo_pessoa = cliente.tipo_pessoa;
            this.recordKey = $"[{cliente.cod_cliente_b2c}]|[{cliente.cod_cliente_erp}]|[{cliente.doc_cliente}]|[{cliente.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
