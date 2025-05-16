using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaLegendasCadastrosAuxiliares
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? empresa { get; private set; }

        [LengthValidation(length: 20, propertyName: "legenda_setor")]
        public string? legenda_setor { get; private set; }

        [LengthValidation(length: 20, propertyName: "legenda_linha")]
        public string? legenda_linha { get; private set; }

        [LengthValidation(length: 20, propertyName: "legenda_marca")]
        public string? legenda_marca { get; private set; }

        [LengthValidation(length: 20, propertyName: "legenda_colecao")]
        public string? legenda_colecao { get; private set; }

        [LengthValidation(length: 20, propertyName: "legenda_grade1")]
        public string? legenda_grade1 { get; private set; }

        [LengthValidation(length: 20, propertyName: "legenda_grade2")]
        public string? legenda_grade2 { get; private set; }

        [LengthValidation(length: 20, propertyName: "legenda_espessura")]
        public string? legenda_espessura { get; private set; }

        [LengthValidation(length: 20, propertyName: "legenda_classificacao")]
        public string? legenda_classificacao { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaLegendasCadastrosAuxiliares() { }

        public B2CConsultaLegendasCadastrosAuxiliares(
            List<ValidationResult> listValidations,
            string? empresa,
            string? legenda_setor,
            string? legenda_linha,
            string? legenda_marca,
            string? legenda_colecao,
            string? legenda_grade1,
            string? legenda_grade2,
            string? legenda_espessura,
            string? legenda_classificacao,
            string? timestamp,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.legenda_setor = legenda_setor;
            this.legenda_linha = legenda_linha;
            this.legenda_marca = legenda_marca;
            this.legenda_colecao = legenda_colecao;
            this.legenda_grade1 = legenda_grade1;
            this.legenda_grade2 = legenda_grade2;
            this.legenda_espessura = legenda_espessura;
            this.legenda_classificacao = legenda_classificacao;
            this.recordXml = recordXml;
        }
    }
}
