using Bloomers.Core.Auditoria.Infrastructure.Logger;
using Dapper;
using IntegrationsCore.Domain.Entities.Enums;
using IntegrationsCore.Domain.Entities.Errors;
using IntegrationsCore.Domain.SqlBuilder;
using IntegrationsCore.Infrastructure.Connections.SQLServer.Auditing;

namespace IntegrationsCore.Infrastructure.Repositorys.LogDetailsRepository
{
    public class LogDetailsRepository : ILogDetailsRepository
    {
        private readonly SqlBuilderTSql _SqlBuilder = new("HOMOLOG_AUDITORIA", "dbo.LogMsgsDetails");

        private readonly IAuditing _conn;

        public LogDetailsRepository(IAuditing conn) =>
            _conn = conn;

        public async Task<int> BulkInsert(IList<LogMsgsDetail> plistLogMsgDetail)
        {
            List<LogMsg> registrosComErro = new();

            try
            {
                using (var conn = _conn.GetDbConnection())
                {
                    foreach (var i_log in plistLogMsgDetail.Where(p => p.IdLogMsg != null && p.IdLogMsgDetail == null).ToList())
                    {
                        var sql = this.BuildCmdSqlString(i_log);
                        try
                        {
                            i_log.IdLogMsgDetail = await conn.QueryFirstOrDefaultAsync<int>(sql, commandTimeout: 10);
                        }
                        catch (Exception ex_loop)
                        {
                            // Exemplo: Lançamento de exception, para o método de chamada logar.
                            throw
                                new LoggerException(ex_loop, EnumIdApp.LogsRepository,
                                      EnumIdLogLevel.Error, EnumIdError.SqlInsert, ex_loop.Message
                                    ).AddAditionalLog(EnumIdLogLevel.Debug, sql);
                        }
                    }
                }
                return plistLogMsgDetail.Count;
            }
            catch (Exception ex)
            {
                var logEx = new LoggerException(
                    ex,
                    EnumIdApp.LogsRepository,
                    EnumIdLogLevel.Error,
                    EnumIdError.SqlInsert
                  );
                throw logEx;
            }
        }
        
        private string BuildCmdSqlString(LogMsgsDetail logMsgDetail, bool isUpdate = false)
        {
            _SqlBuilder.Clear();
            
            _SqlBuilder.Add("IdLogMsg", logMsgDetail.IdLogMsg, EnumSqlBuilderNullAction.set_null);
            _SqlBuilder.Add("FieldKeyValue", logMsgDetail.FieldKeyValue, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("RegText", logMsgDetail.RegText, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("LastUpdateOn", logMsgDetail.LastUpdateOn, EnumSqlBuilderNullAction.ignore);

            if (isUpdate)
                _SqlBuilder.Add("IdLogMsgDetail", logMsgDetail.IdLogMsgDetail, EnumSqlBuilderNullAction.set_null, "", EnumSqlBuilderAddType.where);

            string strSqlCmd = isUpdate ? _SqlBuilder.BuildUpdateSqlCmd() : _SqlBuilder.BuildInsertSqlCmd(true);

            return strSqlCmd;
        }
    }
}
