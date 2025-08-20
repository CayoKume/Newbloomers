
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxLancContabil
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int64? cod_lanc { get; private set; }
        public string? centro_custo { get; private set; }
        public string? ind_conta { get; private set; }
        public Int64? cod_conta { get; private set; }
        public string? nome_conta { get; private set; }
        public decimal? valor_conta { get; private set; }
        public string? cred_deb { get; private set; }
        public DateTime? data_lanc { get; private set; }
        public string? compl_conta { get; private set; }
        public Guid? identificador { get; private set; }
        public Int64? cod_historico { get; private set; }
        public string? desc_historico { get; private set; }
        public DateTime? data_compensacao { get; private set; }
        public Int32? fatura_origem { get; private set; }
        public string? efetivado { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? empresa { get; private set; }
        public Int64? id_lanc { get; private set; }
        public string? cancelado { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxLancContabil() { }

        public LinxLancContabil(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxLancContabil record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.fatura_origem = CustomConvertersExtensions.ConvertToInt32Validation(record.fatura_origem);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cod_lanc = CustomConvertersExtensions.ConvertToInt64Validation(record.cod_lanc);
            this.cod_conta = CustomConvertersExtensions.ConvertToInt64Validation(record.cod_conta);
            this.cod_historico = CustomConvertersExtensions.ConvertToInt64Validation(record.cod_historico);
            this.id_lanc = CustomConvertersExtensions.ConvertToInt64Validation(record.id_lanc);
            this.valor_conta = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_conta);
            this.data_lanc =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_lanc);
            this.data_compensacao =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_compensacao);
            this.identificador = Guid.Parse(record.identificador);
            this.cancelado = record.cancelado;
            this.efetivado = record.efetivado;
            this.desc_historico = record.desc_historico;
            this.compl_conta = record.compl_conta;
            this.cred_deb = record.cred_deb;
            this.nome_conta = record.nome_conta;
            this.ind_conta = record.ind_conta;
            this.centro_custo = record.centro_custo;
            this.cnpj_emp = record.cnpj_emp;
        }
    }
}
