
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxConfiguracoesTributarias
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? id_config_tributaria { get; private set; }
        public string? desc_config_tributaria { get; private set; }
        public string? sigla_config_tributaria { get; private set; }
        public Int64? timestamp { get; private set; }
        public bool? ativa { get; private set; }
        public string? uf { get; private set; }
        public string? sistema_tributacao { get; private set; }
        public Int32? tipo_atividade { get; private set; }
        public Int32? id_origem_mercadoria { get; private set; }
        public bool? utiliza_uso_consumo { get; private set; }
        public Int32? id_classificacao_cest_produto { get; private set; }
        public string? codigo_ws { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxConfiguracoesTributarias() { }

        public LinxConfiguracoesTributarias(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxConfiguracoesTributarias record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_config_tributaria = CustomConvertersExtensions.ConvertToInt32Validation(record.id_config_tributaria);
            this.tipo_atividade = CustomConvertersExtensions.ConvertToInt32Validation(record.tipo_atividade);
            this.id_origem_mercadoria = CustomConvertersExtensions.ConvertToInt32Validation(record.id_origem_mercadoria);
            this.id_classificacao_cest_produto = CustomConvertersExtensions.ConvertToInt32Validation(record.id_classificacao_cest_produto);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.ativa = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativa);
            this.utiliza_uso_consumo = CustomConvertersExtensions.ConvertToBooleanValidation(record.utiliza_uso_consumo);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cnpj_emp = record.cnpj_emp;
            this.desc_config_tributaria = record.desc_config_tributaria;
            this.uf = record.uf;
            this.sigla_config_tributaria = record.sigla_config_tributaria;
            this.sistema_tributacao = record.sistema_tributacao;
            this.codigo_ws = record.codigo_ws;
        }
    }
}
