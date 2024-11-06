using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxMicrovix
{
    public class LinxAcoesPromocionais
    {
        [Column(TypeName = "datetime")]
        public DateTime lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_acoes_promocionais { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? vigencia_inicio { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? vigencia_fim { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? observacao { get; private set; }

        [Column(TypeName = "bit")]
        public bool? ativa { get; private set; }

        [Column(TypeName = "bit")]
        public bool? excluida { get; private set; }

        [Column(TypeName = "bit")]
        public bool? integrada { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtde_integrada { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_pago_franqueadora { get; private set; }

        public LinxAcoesPromocionais() { }

        public LinxAcoesPromocionais(
            string? portal,
            string? cnpj_emp,
            string? id_acoes_promocionais,
            string? descricao,
            string? vigencia_inicio,
            string? vigencia_fim,
            string? observacao,
            string? ativa,
            string? excluida,
            string? integrada,
            string? qtde_integrada,
            string? valor_pago_franqueadora
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);

            this.cnpj_emp =
                cnpj_emp == String.Empty ? ""
                : cnpj_emp.Substring(
                    0,
                    cnpj_emp.Length > 14 ? 14
                    : cnpj_emp.Length
                );

            this.id_acoes_promocionais =
                id_acoes_promocionais == String.Empty ? 0
                : Convert.ToInt32(id_acoes_promocionais);

            this.descricao =
                descricao == String.Empty ? ""
                : descricao.Substring(
                    0,
                    descricao.Length > 100 ? 100
                    : descricao.Length
                );

            this.vigencia_inicio =
                String.IsNullOrEmpty(vigencia_inicio) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(vigencia_inicio);

            this.vigencia_fim =
                String.IsNullOrEmpty(vigencia_fim) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(vigencia_fim);

            this.observacao =
                observacao == String.Empty ? ""
                : descricao;

            this.ativa =
                String.IsNullOrEmpty(ativa) ? false
                : Convert.ToBoolean(ativa);

            this.excluida =
                String.IsNullOrEmpty(excluida) ? false
                : Convert.ToBoolean(excluida);

            this.integrada =
                String.IsNullOrEmpty(integrada) ? false
                : Convert.ToBoolean(integrada);

            this.qtde_integrada =
                qtde_integrada == String.Empty ? 0
                : Convert.ToInt32(qtde_integrada);

            this.valor_pago_franqueadora =
                valor_pago_franqueadora == String.Empty ? 0
                : Convert.ToDecimal(valor_pago_franqueadora);
        }
    }
}
