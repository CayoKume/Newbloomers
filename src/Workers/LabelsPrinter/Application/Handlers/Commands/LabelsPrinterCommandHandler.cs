using LabelsPrinter.Application.Interfaces.Handlers.Commands;
using LabelsPrinter.Domain.Entities;

namespace LabelsPrinter.Application.Handlers.Commands
{
    public class LabelsPrinterCommandHandler : ILabelsPrinterCommandHandler
    {
        public string CreateGetOrdersQuery()
        {
            return $@"SELECT 
	                      A.IDCONTROLE,
	                      A.ZPL
                      FROM 
	                      GENERAL.IT4_WMS_DOCUMENTO_ZPL A (NOLOCK)
                      JOIN
	                      GENERAL.IT4_WMS_DOCUMENTO B (NOLOCK) ON A.IDCONTROLE = B.IDCONTROLE
                      WHERE
	                      B.NB_COD_REMETENTE = 1
	                      AND A.ETIQUETA_IMPRESSA = 0";
        }

        public string CreateUpdateStatusQuery(Int64 idcontrole)
        {
            return $@"UPDATE [GENERAL].[IT4_WMS_DOCUMENTO_ZPL] SET 
	                         ETIQUETA_IMPRESSA = 1
                             WHERE idcontrole = {idcontrole}";
        }
    }
}
