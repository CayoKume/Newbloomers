
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaLegendasCadastrosAuxiliares
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? empresa { get; private set; }
        public string? legenda_setor { get; private set; }
        public string? legenda_linha { get; private set; }
        public string? legenda_marca { get; private set; }
        public string? legenda_colecao { get; private set; }
        public string? legenda_grade1 { get; private set; }
        public string? legenda_grade2 { get; private set; }
        public string? legenda_espessura { get; private set; }
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
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaLegendasCadastrosAuxiliares record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.legenda_setor = record.legenda_setor;
            this.legenda_linha = record.legenda_linha;
            this.legenda_marca = record.legenda_marca;
            this.legenda_colecao = record.legenda_colecao;
            this.legenda_grade1 = record.legenda_grade1;
            this.legenda_grade2 = record.legenda_grade2;
            this.legenda_espessura = record.legenda_espessura;
            this.legenda_classificacao = record.legenda_classificacao;
            this.recordXml = recordXml;
        }
    }
}
