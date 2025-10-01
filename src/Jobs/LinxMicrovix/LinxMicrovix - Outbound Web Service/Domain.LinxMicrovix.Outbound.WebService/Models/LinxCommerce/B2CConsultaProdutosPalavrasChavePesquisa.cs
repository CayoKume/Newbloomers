
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosPalavrasChavePesquisa
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? id_b2c_palavras_chave_pesquisa_produtos { get; private set; }
        public Int32? id_b2c_palavras_chave_pesquisa { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? descricao_b2c_palavras_chave_pesquisa { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosPalavrasChavePesquisa() { }

        public B2CConsultaProdutosPalavrasChavePesquisa(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosPalavrasChavePesquisa record,
            string? recordXml
        )
        {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_b2c_palavras_chave_pesquisa_produtos = CustomConvertersExtensions.ConvertToInt32Validation(record.id_b2c_palavras_chave_pesquisa_produtos);
            this.id_b2c_palavras_chave_pesquisa = CustomConvertersExtensions.ConvertToInt32Validation(record.id_b2c_palavras_chave_pesquisa);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.descricao_b2c_palavras_chave_pesquisa = record.descricao_b2c_palavras_chave_pesquisa;
            this.recordXml = recordXml;
        }
    }
}
