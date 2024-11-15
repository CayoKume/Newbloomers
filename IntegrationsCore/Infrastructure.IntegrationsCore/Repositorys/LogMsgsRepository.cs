using Dapper;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Errors;
using Domain.IntegrationsCore.Exceptions;
using Domain.IntegrationsCore.Interfaces;
using Domain.IntegrationsCore.SqlBuilder;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Microsoft.Extensions.Configuration;

namespace IntegrationsCore.Infrastructure.Repository.LogMsgsRepository
{

    public class LogMsgsRepository : ILogMsgsRepository
    {
        private readonly SqlBuilderTSql _SqlBuilder = new("HOMOLOG_AUDITORIA", "dbo.LogMsgs");

        private readonly string? _catalog;
        private readonly IConfiguration _config;
        private readonly ISQLServerConnection _conn;

        public LogMsgsRepository(ISQLServerConnection conn, IConfiguration config)
        {
            _conn = conn;
            _config = config;

            _catalog = _config
                .GetSection("ConfigureServer")
                .GetSection("AuditingDatabaseName")
                .Value;
        }

        public async Task<int> BulkInsert(IList<ILogMsg> plistLogMsg)
        {
            IList<LogMsg> registrosComErro = new List<LogMsg>();
            
            try
            {
                using (var conn = _conn.GetDbConnection(_catalog))
                {
                    int? idLogMsgParent = null;
                    foreach (var i_log in plistLogMsg.Where(p=>p.IdLogMsg==null).ToList())
                    {
                        if (idLogMsgParent != null)
                            i_log.IdLogMsgParent = idLogMsgParent;

                        var sql = this.BuildCmdSqlString(i_log);
                        try
                        {
                            // Processa atualização e obtém o Identity
                            i_log.IdLogMsg = await conn.QueryFirstOrDefaultAsync<int>(sql, commandTimeout: 360);

                            if (idLogMsgParent == null)
                                idLogMsgParent = i_log.IdLogMsg;

                            // Atualiza nos filhos LogMsgDetails o Id
                            foreach (var i_det in i_log.LogMsgDetails)
                                i_det.IdLogMsg = i_log.IdLogMsg;

                            // Atualiza nos filhos LogStatus o Id
                            foreach (var i_status in i_log.LogStatus)
                                i_status.IdLogMsg = i_log.IdLogMsg;
                        }
                        catch (Exception ex_loop)
                        {
                            // Exemplo: Lançamento de exception, para o método de chamada logar.
                            throw 
                                new LoggerException(ex_loop, EnumIdApp.LogsRepository,
                                      EnumIdLogLevel.Error, EnumIdError.SqlInsert, ex_loop.Message
                                    ).AddLog(error: EnumIdError.SQLCommand, level: EnumIdLogLevel.Debug, message: sql);
                        }
                    }
                }
                return plistLogMsg.Count;
            }
            catch (Exception ex)
            {
                throw new LoggerException(ex,EnumIdApp.LogsRepository,
                    EnumIdLogLevel.Error, EnumIdError.SqlInsert);
            }
        }

        /// <summary>
        /// Método para retornar o comando insert / update da classe específica.
        /// </summary>
        /// <param name="logMsg">Entidade tipo ILogMsg</param>
        /// <param name="isUpdate">Comando do Tipo Update = TRUE, ou false = INSERT</param>
        /// <returns>retorna uma string com o comando SQL</returns>
        private string BuildCmdSqlString(ILogMsg logMsg,bool isUpdate = false)
        {
            _SqlBuilder.Clear();
            _SqlBuilder.Add<EnumIdApp>("IdApp", logMsg.IdApp);
            _SqlBuilder.Add<EnumIdError>("IdError", logMsg.IdError);
            _SqlBuilder.Add<EnumIdDomain>("IdDomain", logMsg.IdDomain);
            _SqlBuilder.Add<EnumIdLogLevel>("IdLogLevel", logMsg.IdLogLevel);
            _SqlBuilder.Add("TextLog", logMsg.TextLog, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("AppName", logMsg.AppName, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("Checked", logMsg.Checked, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("ValueKeyFields", logMsg.ValueKeyFields, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("LastUpdateOn", logMsg.LastUpdateOn, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("LastUpdateUser", logMsg.LastUpdateUser, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("StartDate", logMsg.StartDate, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("EndDate", logMsg.EndDate, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add<EnumIdSteps>("IdStep", logMsg.IdStep);
            _SqlBuilder.Add("IdLogMsgParent", logMsg.IdLogMsgParent, EnumSqlBuilderNullAction.ignore);

            // Quando update, adicionar um where
            if (isUpdate && logMsg.IdLogMsg != null)
                _SqlBuilder.Add("IdLogMsg", logMsg.IdLogMsg, EnumSqlBuilderNullAction.ignore, "", EnumSqlBuilderAddType.where);

            if (isUpdate)
                _SqlBuilder.BuildUpdateSqlCmd();
            else
                _SqlBuilder.BuildInsertSqlCmd(true);

            return _SqlBuilder.LastSql;
        }
    }
}
