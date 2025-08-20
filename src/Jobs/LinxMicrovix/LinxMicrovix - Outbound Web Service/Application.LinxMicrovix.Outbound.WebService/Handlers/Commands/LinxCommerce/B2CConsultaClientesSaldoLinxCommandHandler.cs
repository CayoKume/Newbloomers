using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaClientesSaldoLinxCommandHandler : IB2CConsultaClientesSaldoLinxCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaClientesSaldoLinx> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.cod_cliente_b2c}'"));
            return $"SELECT CONCAT('[', COD_CLIENTE_B2C, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACLIENTESSALDOLINX] WHERE COD_CLIENTE_B2C IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [cod_cliente_erp], [cod_cliente_b2c], [empresa], [valor], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @cod_cliente_erp, @cod_cliente_b2c, @empresa, @valor, @timestamp, @portal)";
        }
    }
}
