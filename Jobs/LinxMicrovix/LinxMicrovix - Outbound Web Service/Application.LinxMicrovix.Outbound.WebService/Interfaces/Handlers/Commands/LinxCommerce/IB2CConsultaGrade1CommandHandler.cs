using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce
{
    public interface IB2CConsultaGrade1CommandHandler
    {
        string CreateGetRegistersExistsQuery(List<B2CConsultaGrade1> registros);
        string CreateInsertRecordQuery(string tableName);
    }
}
