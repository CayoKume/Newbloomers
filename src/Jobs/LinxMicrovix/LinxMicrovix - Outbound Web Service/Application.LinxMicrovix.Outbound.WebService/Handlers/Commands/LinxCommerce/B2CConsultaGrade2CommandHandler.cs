using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaGrade2CommandHandler : IB2CConsultaGrade2CommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaGrade2> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigo_grade2}'"));
            return $"SELECT CONCAT('[', CODIGO_GRADE2, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAGRADE2] WHERE CODIGO_GRADE2 IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [codigo_grade2], [nome_grade2], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @codigo_grade2, @nome_grade2, @timestamp, @portal)";
        }
    }
}
