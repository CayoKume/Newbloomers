using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoCartoes
    {
        public DateTime? lastupdateon { get; private set; }

        public Guid? identificador { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [LengthValidation(length: 10, propertyName: "codlojasitef")]
        public string? codlojasitef { get; private set; }

        public DateTime? data_lancamento { get; private set; }

        [LengthValidation(length: 20, propertyName: "cupomfiscal")]
        public string? cupomfiscal { get; private set; }

        [LengthValidation(length: 1, propertyName: "credito_debito")]
        public string? credito_debito { get; private set; }

        public Int32? id_cartao_bandeira { get; private set; }

        [LengthValidation(length: 100, propertyName: "descricao_bandeira")]
        public string? descricao_bandeira { get; private set; }

        public decimal? valor { get; private set; }

        public Int32? ordem_cartao { get; private set; }

        [LengthValidation(length: 50, propertyName: "nsu_host")]
        public string? nsu_host { get; private set; }

        [LengthValidation(length: 50, propertyName: "nsu_sitef")]
        public string? nsu_sitef { get; private set; }

        [LengthValidation(length: 50, propertyName: "cod_autorizacao")]
        public string? cod_autorizacao { get; private set; }

        public Int32? id_antecipacoes_financeiras { get; private set; }

        public bool? transacao_servico_terceiro { get; private set; }

        public string? texto_comprovante { get; private set; }

        public Int32? id_maquineta_pos { get; private set; }

        [LengthValidation(length: 50, propertyName: "descricao_maquineta")]
        public string? descricao_maquineta { get; private set; }

        [LengthValidation(length: 50, propertyName: "serie_maquineta")]
        public string? serie_maquineta { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 1, propertyName: "cartao_prepago")]
        public string? cartao_prepago { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoCartoes() { }

        public LinxMovimentoCartoes(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? codlojasitef,
            string? data_lancamento,
            string? identificador,
            string? cupomfiscal,
            string? credito_debito,
            string? id_cartao_bandeira,
            string? descricao_bandeira,
            string? valor,
            string? ordem_cartao,
            string? nsu_host,
            string? nsu_sitef,
            string? cod_autorizacao,
            string? id_antecipacoes_financeiras,
            string? transacao_servico_terceiro,
            string? texto_comprovante,
            string? id_maquineta_pos,
            string? descricao_maquineta,
            string? serie_maquineta,
            string? timestamp,
            string? cartao_prepago,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_cartao_bandeira =
                ConvertToInt32Validation.IsValid(id_cartao_bandeira, "id_cartao_bandeira", listValidations) ?
                Convert.ToInt32(id_cartao_bandeira) :
                0;

            this.ordem_cartao =
                ConvertToInt32Validation.IsValid(ordem_cartao, "ordem_cartao", listValidations) ?
                Convert.ToInt32(ordem_cartao) :
                0;

            this.id_antecipacoes_financeiras =
                ConvertToInt32Validation.IsValid(id_antecipacoes_financeiras, "id_antecipacoes_financeiras", listValidations) ?
                Convert.ToInt32(id_antecipacoes_financeiras) :
                0;

            this.id_maquineta_pos =
                ConvertToInt32Validation.IsValid(id_maquineta_pos, "id_maquineta_pos", listValidations) ?
                Convert.ToInt32(id_maquineta_pos) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.data_lancamento =
                ConvertToDateTimeValidation.IsValid(data_lancamento, "data_lancamento", listValidations) ?
                Convert.ToDateTime(data_lancamento) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.valor =
                ConvertToDecimalValidation.IsValid(valor, "valor", listValidations) ?
                Convert.ToDecimal(valor, new CultureInfo("en-US")) :
                0;

            this.transacao_servico_terceiro =
                ConvertToBooleanValidation.IsValid(transacao_servico_terceiro, "transacao_servico_terceiro", listValidations) ?
                Convert.ToBoolean(transacao_servico_terceiro) :
                false;

            this.cnpj_emp = cnpj_emp;
            this.codlojasitef = codlojasitef;
            this.cupomfiscal = cupomfiscal;
            this.credito_debito = credito_debito;
            this.descricao_bandeira = descricao_bandeira;
            this.nsu_host = nsu_host;
            this.nsu_sitef = nsu_sitef;
            this.cod_autorizacao = cod_autorizacao;
            this.texto_comprovante = texto_comprovante;
            this.descricao_maquineta = descricao_maquineta;
            this.serie_maquineta = serie_maquineta;
            this.cartao_prepago = cartao_prepago;
            this.recordKey = $"[{cnpj_emp}]|[{cupomfiscal}]|[{cod_autorizacao}]|[{identificador}]|[{timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
