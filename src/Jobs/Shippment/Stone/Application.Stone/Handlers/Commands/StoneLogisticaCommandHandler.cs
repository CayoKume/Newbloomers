using Application.Stone.Interfaces.Handlers.Commands;

namespace Application.Stone.Handlers.Commands
{
    public class StoneLogisticaCommandHandler : IStoneLogisticaCommandHandler
    {
        public string CreateGetParametersQuery()
        {
            return $"SELECT DISTINCT email, password  FROM [general].[Parametros_StoneLogistica]";
        }

        public string CreateGetRegistersExistsQuery()
        {
            return $@"SELECT DISTINCT 
	                      TRIM(DOCUMENTO)
                      FROM 
	                      GENERAL.IT4_WMS_DOCUMENTO A (NOLOCK)
                      LEFT JOIN 
	                      GENERAL.STONELOGISTICAORDERS B (NOLOCK) on A.DOCUMENTO = REPLACE(B.REFERENCEKEY, '3294_29_', '')
                      WHERE 
	                      A.NB_COD_TRANSPORTADORA = 97586
                      AND
                          A.CHAVE_NFE IS NOT NULL
                      AND 
	                      A.DOCUMENTO NOT LIKE '%-VD%'
                      AND 
	                      A.DOCUMENTO NOT LIKE '%-VF%'
                      AND 
	                      A.DOCUMENTO NOT LIKE '%-LJ%'
                      AND 
	                      A.DATA > CAST(GETDATE() -7 AS DATE)
                      AND 
	                      B.REFERENCEKEY IS NULL";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            throw new NotImplementedException();
        }
    }
}
