using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxTrocaUnificadaResumoBaixa", Schema = "untreated")]
    public class LinxTrocaUnificadaResumoBaixa
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal_baixa { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa_baixa { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_empresa_baixa { get; private set; }

        [Column(TypeName = "int")]
        public string? id_troca_baixa { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? id_troca_unificada_resumo_vendas_itens { get; private set; }

        [Column(TypeName = "int")]
        public string? data_troca_baixa { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao_baixa { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? descricao_empresa_baixa { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
