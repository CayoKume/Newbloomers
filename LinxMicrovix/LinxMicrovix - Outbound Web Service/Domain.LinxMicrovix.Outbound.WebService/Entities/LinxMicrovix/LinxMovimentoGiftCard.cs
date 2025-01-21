using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxMovimentoGiftCard", Schema = "linx_microvix_erp")]
    public class LinxMovimentoGiftCard
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_transacao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? operacao { get; private set; }

        [Column(TypeName = "varchar(100)")]
        [LengthValidation(length: 100, propertyName: "nsu_cliente")]
        public string? nsu_cliente { get; private set; }

        [Column(TypeName = "varchar(100)")]
        [LengthValidation(length: 100, propertyName: "nsu_host")]
        public string? nsu_host { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? json_envio { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string json_retorno { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtde_tentativa { get; private set; }

        [Column(TypeName = "varchar(4)")]
        [LengthValidation(length: 4, propertyName: "aprovado_barramento")]
        public string? aprovado_barramento { get; private set; }

        [Column(TypeName = "bit")]
        public bool? estornada { get; private set; }

        [Column(TypeName = "varchar(100)")]
        [LengthValidation(length: 100, propertyName: "codigo_loja")]
        public string? codigo_loja { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador_movimento { get; private set; }

        [Column(TypeName = "varchar(100)")]
        [LengthValidation(length: 100, propertyName: "numero_cartao")]
        public string? numero_cartao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? plano { get; private set; }

        [Column(TypeName = "bit")]
        public bool? ambiente_producao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxMovimentoGiftCard() { }

        public LinxMovimentoGiftCard(
            List<ValidationResult> listValidations,
            string? empresa,
            string? data_transacao,
            string? operacao,
            string? nsu_cliente,
            string? nsu_host,
            string? valor,
            string? json_envio,
            string? json_retorno,
            string? qtde_tentativa,
            string? aprovado_barramento,
            string? estornada,
            string? codigo_loja,
            string? identificador_movimento,
            string? numero_cartao,
            string? plano,
            string? ambiente_producao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.operacao =
                ConvertToInt32Validation.IsValid(operacao, "operacao", listValidations) ?
                Convert.ToInt32(operacao) :
                0;

            this.qtde_tentativa =
                ConvertToInt32Validation.IsValid(qtde_tentativa, "qtde_tentativa", listValidations) ?
                Convert.ToInt32(qtde_tentativa) :
                0;

            this.plano =
                ConvertToInt32Validation.IsValid(plano, "plano", listValidations) ?
                Convert.ToInt32(plano) :
                0;

            this.valor =
                ConvertToDecimalValidation.IsValid(valor, "valor", listValidations) ?
                Convert.ToDecimal(valor) :
                0;

            this.estornada =
                ConvertToBooleanValidation.IsValid(estornada, "estornada", listValidations) ?
                Convert.ToBoolean(estornada) :
                false;

            this.ambiente_producao =
                ConvertToBooleanValidation.IsValid(ambiente_producao, "ambiente_producao", listValidations) ?
                Convert.ToBoolean(ambiente_producao) :
                false;

            this.data_transacao =
                ConvertToDateTimeValidation.IsValid(data_transacao, "data_transacao", listValidations) ?
                Convert.ToDateTime(data_transacao) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.identificador_movimento =
                String.IsNullOrEmpty(identificador_movimento) ? null
                : Guid.Parse(identificador_movimento);

            this.nsu_cliente = nsu_cliente;
            this.nsu_host = nsu_host;
            this.json_envio = json_envio;
            this.json_retorno = json_retorno;
            this.aprovado_barramento = aprovado_barramento;
            this.codigo_loja = codigo_loja;
            this.numero_cartao = numero_cartao;
        }
    }
}
