using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaEmpresas
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? empresa { get; private set; }
        public string? nome_emp { get; private set; }
        public string? cnpj_emp { get; private set; }
        public string? end_unidade { get; private set; }
        public string? complemento_end_unidade { get; private set; }
        public string? nr_rua_unidade { get; private set; }
        public string? bairro_unidade { get; private set; }
        public string? cep_unidade { get; private set; }
        public string? cidade_unidade { get; private set; }
        public string? uf_unidade { get; private set; }
        public string? email_unidade { get; private set; }
        public Int64? timestamp { get; private set; }
        public DateTime? data_criacao { get; private set; }
        public bool? centro_distribuicao { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaEmpresas() { }

        public B2CConsultaEmpresas(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaEmpresas record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.data_criacao = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_criacao);
            this.centro_distribuicao = CustomConvertersExtensions.ConvertToBooleanValidation(record.centro_distribuicao);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.nome_emp = record.nome_emp;
            this.cnpj_emp = record.cnpj_emp;
            this.end_unidade = record.end_unidade;
            this.complemento_end_unidade = record.complemento_end_unidade;
            this.nr_rua_unidade = record.nr_rua_unidade;
            this.bairro_unidade = record.bairro_unidade;
            this.cep_unidade = record.cep_unidade;
            this.cidade_unidade = record.cidade_unidade;
            this.uf_unidade = record.uf_unidade;
            this.email_unidade = record.end_unidade;
            this.recordKey = $"[{record.empresa}]|[{record.cnpj_emp}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
