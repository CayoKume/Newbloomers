using Dapper;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Domain.IntegrationsCore.Entities.Errors;
using Domain.IntegrationsCore.SqlBuilder;
using Domain.IntegrationsCore.Exceptions;
using Domain.IntegrationsCore.Entities.Enums;
using Microsoft.Extensions.Configuration;
using Domain.IntegrationsCore.Interfaces;

namespace IntegrationsCore.Infrastructure.Repositorys.LogDetailsRepository
{
    public class LogDetailsRepository : ILogDetailsRepository
    {
        private readonly SqlBuilderTSql _SqlBuilder = new("HOMOLOG_AUDITORIA", "dbo.LogMsgsDetails");

        private readonly string? _catalog;
        private readonly IConfiguration _config;
        private readonly ISQLServerConnection _conn;

        public LogDetailsRepository(ISQLServerConnection conn, IConfiguration config)
        {
            _conn = conn;
            _config = config;

            _catalog = _config
                .GetSection("ConfigureServer")
                .GetSection("AuditingDatabaseName")
                .Value;
        }

        public async Task<int> BulkInsert(IList<LogMsgsDetail> plistLogMsgDetail)
        {
            List<LogMsg> registrosComErro = new();

            try
            {
                using (var conn = _conn.GetDbConnection(_catalog))
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
                                    ).AddLog(EnumIdLogLevel.Debug, sql);
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
