using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaClientesSaldoCommandHandler : IB2CConsultaClientesSaldoCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaClientesSaldo> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.cod_cliente_erp}'"));
            return $"SELECT CONCAT('[', COD_CLIENTE_ERP, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACLIENTESSALDO] WHERE COD_CLIENTE_ERP IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [saldo], [cod_cliente_erp], [empresa], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @saldo, @cod_cliente_erp, @empresa, @timestamp, @portal)";
        }
    }
}
