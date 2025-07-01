using Dapper;
using Domain.Dootax.Entities;
using Domain.Dootax.Interfaces.Repositorys;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;
using Infrastructure.IntegrationsCore.Connections.SQLServer;

namespace Infrastructure.Dootax.Repositorys
{
    public class DootaxRepository : IDootaxRepository
    {
        private readonly ISQLServerConnection _conn;

        public DootaxRepository(ISQLServerConnection conn) =>
            _conn = conn;

        public async Task<IEnumerable<XML>> GetXMLs()
        {
            var sql = @$"SELECT 
                            A.DOCUMENTO AS DOCUMENTO,
                            A.CNPJ_EMP AS CNPJCPF,
                            A.SERIE AS SERIE,
                            A.CHAVE_NFE AS CHAVENFE,
                            A.XMLDISTRIBUICAO AS DSXML
                        FROM 
                        LINX_MICROVIX_ERP.LINXXMLDOCUMENTOS A (NOLOCK)
                        LEFT JOIN GENERAL.DOOTAX_SUCCESSFUL_LOG B (NOLOCK) on A.CHAVE_NFE = B.CHAVE_NFE
						JOIN LINX_MICROVIX_ERP.LINXMOVIMENTO C (NOLOCK) on A.CHAVE_NFE = C.CHAVE_NF
						JOIN LINX_MICROVIX_ERP.LINXCLIENTESFORNEC D (NOLOCK) on C.CODIGO_CLIENTE = D.COD_CLIENTE
						JOIN LINX_MICROVIX_ERP.LINXLOJAS E (NOLOCK) on A.CNPJ_EMP = E.CNPJ_EMP
                        WHERE
                            A.CHAVE_NFE IS NOT NULL
							AND A.XMLDISTRIBUICAO != ''
                            AND A.DATA_EMISSAO > GETDATE() - 7
                            AND A.DOCUMENTO IS NOT NULL
                            AND A.XMLDISTRIBUICAO IS NOT NULL
							AND B.CHAVE_NFE IS NULL 
                            AND D.UF_CLIENTE != E.ESTADO_EMP
							--NÃO PEGA REPOSIÇÃO DE LOJAS (-LJ)
							AND D.RAZAO_CLIENTE NOT LIKE '%MNR%'
							AND D.RAZAO_CLIENTE NOT LIKE '%NEWFIT%'

                        UNION ALL

                        SELECT 
                            A.DOCUMENTO AS DOCUMENTO,
                            C.CNPJ_EMP AS CNPJCPF,
                            A.SERIE AS SERIE,
                            A.CHAVE_NFE AS CHAVENFE,
                            A.[XML] AS DSXML
                        FROM 
                        LINX_MICROVIX_COMMERCE.B2CCONSULTANFE A (NOLOCK)
                        LEFT JOIN GENERAL.DOOTAX_SUCCESSFUL_LOG B (NOLOCK) on A.CHAVE_NFE = B.CHAVE_NFE
						JOIN LINX_MICROVIX_ERP.LINXMOVIMENTO C (NOLOCK) on A.CHAVE_NFE = C.CHAVE_NF
						JOIN LINX_MICROVIX_ERP.LINXCLIENTESFORNEC D (NOLOCK) on C.CODIGO_CLIENTE = D.COD_CLIENTE
						JOIN LINX_MICROVIX_ERP.LINXLOJAS E (NOLOCK) on C.CNPJ_EMP = E.CNPJ_EMP
                        WHERE
                            A.CHAVE_NFE IS NOT NULL
							AND A.[XML] != ''
                            AND A.DATA_EMISSAO > GETDATE() - 7
                            AND A.DOCUMENTO IS NOT NULL
                            AND A.[XML] IS NOT NULL
							AND B.CHAVE_NFE IS NULL 
							AND D.UF_CLIENTE != E.ESTADO_EMP
							--NÃO PEGA REPOSIÇÃO DE LOJAS (-LJ)
							AND D.RAZAO_CLIENTE NOT LIKE '%MNR%'
							AND D.RAZAO_CLIENTE NOT LIKE '%NEWFIT%'

                        ORDER BY DOCUMENTO ASC";

            try
            {
                using (var conn = _conn.GetDbConnection())
                {
                    return await conn.QueryAsync<XML>(sql, commandTimeout: 360);
                }
            }
            catch (Exception ex)
            {
                throw new InternalException(
                    stage: EnumStages.GetRegistersExists,
                    error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error getting xmls from table GENERAL..IT4_WMS_DOCUMENTO",
                    exceptionMessage: ex.Message
                );
            }
        }

        public async Task InsertSendFilesSuccessfulLog(string cnpjcpf, string documento, string serie, string chavenfe)
        {
            var sql = @$"INSERT INTO GENERAL.DOOTAX_SUCCESSFUL_LOG
                                (cnpj_emp, documento, serie, chave_nfe, dt_insert)
                          VALUES 
                                (@cnpj_emp, @documento, @serie, @chave_nfe, @dt_insert)";

            try
            {
                using (var conn = _conn.GetDbConnection())
                {
                    await conn.ExecuteAsync(sql, new
                    {
                        cnpj_emp = cnpjcpf,
                        documento,
                        serie,
                        chave_nfe = chavenfe,
                        dt_insert = DateTime.Now
                    }, commandTimeout: 360);
                }
            }
            catch (Exception ex)
            {
                throw new InternalException(
                    stage: EnumStages.GetRegistersExists,
                    error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error getting xmls from table GENERAL..IT4_WMS_DOCUMENTO",
                    exceptionMessage: ex.Message
                );
            }
        }
    }
}
