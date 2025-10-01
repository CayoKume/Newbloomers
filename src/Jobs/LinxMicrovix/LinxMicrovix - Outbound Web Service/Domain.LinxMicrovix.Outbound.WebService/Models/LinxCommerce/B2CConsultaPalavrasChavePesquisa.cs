
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaPalavrasChavePesquisa
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? id_b2c_palavras_chave_pesquisa { get; private set; }
        public string? nome_colecao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaPalavrasChavePesquisa() { }

        public B2CConsultaPalavrasChavePesquisa(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaPalavrasChavePesquisa record,
            string? recordXml
        )
        {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_b2c_palavras_chave_pesquisa = CustomConvertersExtensions.ConvertToInt32Validation(record.id_b2c_palavras_chave_pesquisa);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.nome_colecao = record.nome_colecao;
            this.recordXml = recordXml;
        }
    }
}
