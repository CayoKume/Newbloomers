using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoBaixa
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal_baixa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa_baixa { get; private set; }

        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "cnpj_empresa_baixa")]
        public string? cnpj_empresa_baixa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_troca_baixa { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? id_troca_unificada_resumo_vendas_itens { get; private set; }

        [Column(TypeName = "int")]
        public DateTime? data_troca_baixa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? transacao_baixa { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "descricao_empresa_baixa")]
        public string? descricao_empresa_baixa { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxTrocaUnificadaResumoBaixa() { }

        public LinxTrocaUnificadaResumoBaixa(
            List<ValidationResult> listValidations,
            string? portal_baixa,
            string? empresa_baixa,
            string? cnpj_empresa_baixa,
            string? id_troca_baixa,
            string? id_troca_unificada_resumo_vendas_itens,
            string? data_troca_baixa,
            string? transacao_baixa,
            string? descricao_empresa_baixa,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal_baixa =
                ConvertToInt32Validation.IsValid(portal_baixa, "portal_baixa", listValidations) ?
                Convert.ToInt32(portal_baixa) :
                0;

            this.empresa_baixa =
                ConvertToInt32Validation.IsValid(empresa_baixa, "empresa_baixa", listValidations) ?
                Convert.ToInt32(empresa_baixa) :
                0;

            this.id_troca_baixa =
                ConvertToInt32Validation.IsValid(id_troca_baixa, "id_troca_baixa", listValidations) ?
                Convert.ToInt32(id_troca_baixa) :
                0;

            this.transacao_baixa =
                ConvertToInt32Validation.IsValid(transacao_baixa, "transacao_baixa", listValidations) ?
                Convert.ToInt32(transacao_baixa) :
                0;

            this.data_troca_baixa =
               ConvertToDateTimeValidation.IsValid(data_troca_baixa, "data_troca_baixa", listValidations) ?
               Convert.ToDateTime(data_troca_baixa) :
               new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.id_troca_unificada_resumo_vendas_itens =
                ConvertToInt64Validation.IsValid(id_troca_unificada_resumo_vendas_itens, "id_troca_unificada_resumo_vendas_itens", listValidations) ?
                Convert.ToInt64(id_troca_unificada_resumo_vendas_itens) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cnpj_empresa_baixa = cnpj_empresa_baixa;
            this.descricao_empresa_baixa = descricao_empresa_baixa;
        }
    }
}
