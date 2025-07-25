using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaGrade1CommandHandler : IB2CConsultaGrade1CommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaGrade1> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigo_grade1}'"));
            return $"SELECT CONCAT('[', CODIGO_GRADE1, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAGRADE1] WHERE CODIGO_GRADE1 IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [codigo_grade1], [nome_grade1], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @codigo_grade1, @nome_grade1, @timestamp, @portal)";
        }
    }
}
