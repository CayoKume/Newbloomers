using Bloomers.Core.Auditoria.Infrastructure.Logger;
using Dapper;
using IntegrationsCore.Domain.Entities.Enums;
using IntegrationsCore.Domain.Entities.Errors;
using IntegrationsCore.Domain.SqlBuilder;
using IntegrationsCore.Infrastructure.Connections.SQLServer.Auditing;

namespace IntegrationsCore.Infrastructure.Repository.LogStatusRepository
{
    public class LogStatusRepository : ILogStatusRepository
    {
        private readonly SqlBuilderTSql _SqlBuilder = new("HOMOLOG_AUDITORIA", "dbo.LogStatus");

        private readonly IAuditing _conn;
        
        public LogStatusRepository(IAuditing conn) =>
            _conn = conn;

        public async Task Update(LogStatus status)
        {
            string cmdText = BuildCmdSqlString(status);
            try
            {
                using (var conn = _conn.GetDbConnection())
                {
                    await conn.ExecuteAsync(cmdText, commandTimeout: 10);
                }
            }
            catch (Exception ex)
            {
                // Exemplo: Lançamento de exception, para o método de chamada logar.
                // Gravando dois logs, um com a exception e outro de debug, com o comando sql executado 
                // Podemos Especificar Melhor o Id De Cada Erro Definindo Rotinas específicas Dentro Do Processo
                /// categorizando logs, status, detalhe, etc.
                throw
                    new LoggerException(ex, EnumIdApp.LogsRepository,
                          EnumIdLogLevel.Error, EnumIdError.SqlInsert, ex.Message
                        ).AddLog(EnumIdLogLevel.Debug, cmdText);
            }
        }

        private string BuildCmdSqlString(LogStatus status)
        {
            _SqlBuilder.Clear();
            _SqlBuilder.Add<EnumIdDomain>("IdDomain", status.IdDomain);
            _SqlBuilder.Add<EnumIdLogLevel>("IdLogLevel", status.IdLogLevel);
            _SqlBuilder.Add("IdLogMsg", status.IdLogMsg, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("Msg", status.Msg, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("Detail", status.Detail, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("StartDate", status.StartDate, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("EndDate", status.EndDate, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("CountErrors", status.CountErrors, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("LastIdLogMsg", status.LastIdLogMsg, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("LastUpdateOn", status.LastUpdateOn, EnumSqlBuilderNullAction.ignore);
            _SqlBuilder.Add("LastUpdateUser", status.LastUpdateUser, EnumSqlBuilderNullAction.ignore);

            // Add Where
            _SqlBuilder.Add<EnumIdApp>("IdApp", status.IdApp, EnumSqlBuilderAddType.where);

            string strSql = _SqlBuilder.BuildUpdateSqlCmd();

            return strSql;
        }
    }
}

