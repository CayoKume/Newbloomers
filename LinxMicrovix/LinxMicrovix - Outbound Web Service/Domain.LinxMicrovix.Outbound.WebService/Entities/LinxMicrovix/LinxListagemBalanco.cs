using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.CustomValidations;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxListagemBalanco
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_balanco { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "nome_arquivo")]
        public string? nome_arquivo { get; private set; }
        
        [Column(TypeName = "varchar(1)")]
        [LengthValidation(length: 1, propertyName: "processado")]
        public string? processado { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_ultimo_processamento { get; private set; }

        [Column(TypeName = "int")]
        public Int32 qtde_produtos { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtde_itens { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxListagemBalanco() { }

        public LinxListagemBalanco(
            List<ValidationResult> listValidations,
            string? id_balanco,
            string? data,
            string? nome_arquivo,
            string? processado,
            string? data_ultimo_processamento,
            string? qtde_produtos,
            string? qtde_itens,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_balanco =
                ConvertToInt32Validation.IsValid(id_balanco, "id_balanco", listValidations) ?
                Convert.ToInt32(id_balanco) :
                0;

            this.qtde_produtos =
                ConvertToInt32Validation.IsValid(qtde_produtos, "qtde_produtos", listValidations) ?
                Convert.ToInt32(qtde_produtos) :
                0;

            this.qtde_itens =
                ConvertToInt32Validation.IsValid(qtde_itens, "qtde_itens", listValidations) ?
                Convert.ToInt32(qtde_itens) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.data =
                ConvertToDateTimeValidation.IsValid(data, "data", listValidations) ?
                Convert.ToDateTime(data) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_ultimo_processamento =
                ConvertToDateTimeValidation.IsValid(data_ultimo_processamento, "data_ultimo_processamento", listValidations) ?
                Convert.ToDateTime(data_ultimo_processamento) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.nome_arquivo = nome_arquivo;
            this.processado = processado;
        }
    }
}
