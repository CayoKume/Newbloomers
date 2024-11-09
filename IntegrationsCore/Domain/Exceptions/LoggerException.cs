using System.Runtime.Serialization;
using IntegrationsCore.Domain.Entities.Errors;
using IntegrationsCore.Domain.Entities.Enums;


namespace Bloomers.Core.Auditoria.Infrastructure.Logger
{
    /// <summary>
    /// Gera uma exception do registro com apontamento correto para classificação correta.
    /// Esta classe é útil, quando em sub-metodos, queremos logar um erro específico,
    /// mas não teremos acesso ao contexto da classe de logs por ela não ser global.
    /// A solução é, que podemos registar via exception, este log, com n IdApp e IdError correto
    /// Então ao capturar, a exception, teremos n erro, correto a logar.
    /// Depois , capturamos esta exception e registramos n log
    /// </summary>
    public class LoggerException : Exception, ISerializable
    {

        /// <summary>
        /// Lista de Mensagens Inseridas. 
        /// Use n AddLog para inserir uma mensagem nova.
        /// </summary>
        public IList<LogMsg> LogsMsgs { get; private set; } = [];

        /// <summary>
        /// Adicionar uma exception
        /// </summary>
        /// <param name="idApp"></param>
        /// <param name="level"></param>
        /// <param name="idError"></param>
        /// <param name="string_Key"></param>
        /// <param name="message_log_detalhes_da_ocorrencia"></param>
        /// <param name="user"></param>
        public LoggerException(EnumIdApp idApp
                                    , EnumIdLogLevel level
                                    , EnumIdError idError = EnumIdError.Undefined
                                    , string message_log_detalhes_da_ocorrencia = ""
                                    , string? string_Key = null
                                    , string user = ""
                                    , Exception? pInnerException = null
                                    ) : base(message_log_detalhes_da_ocorrencia, pInnerException)
        {
            string msgError = string.Empty;
            if (pInnerException != null)
                msgError = pInnerException.Message;
            var newLogMsg = new LogMsg()
            {
                IdApp = idApp,
                IdLogLevel = level,
                IdError = idError,
                ValueKeyFields = string_Key,
                TextLog = $"{message_log_detalhes_da_ocorrencia} {msgError}",
                LastUpdateUser = user,
            };

            LogsMsgs.Add(newLogMsg);
        }

        /// <summary>
        /// Criar uma Exception: Opção para criar exception de forma simplificada
        /// sem o idApp, quando estamos em rotinas filhas GENERICAS, e então vamos 
        /// lançar para uma rotina PAI, eo APP será definido lá.
        /// Neste caso não há como definir o idApp
        /// </summary>
        /// <param name="level"></param>
        /// <param name="idError"></param>
        /// <param name="string_Key"></param>
        /// <param name="message_log_detalhes_da_ocorrencia"></param>
        /// <param name="user"></param>
        public LoggerException(EnumIdError idError
                              , EnumIdLogLevel level
                              , string message_log_detalhes_da_ocorrencia = ""
                   ) : base(message_log_detalhes_da_ocorrencia)
        {
            var newLogMsg = new LogMsg()
            {
                IdLogLevel = level,
                IdError = idError,
                TextLog = $"{message_log_detalhes_da_ocorrencia}",
            };

            LogsMsgs.Add(newLogMsg);
        }

        /// <summary>
        /// Este override permite passar uma innerException, início
        /// </summary>
        /// <param name="idApp"></param>
        /// <param name="level"></param>
        /// <param name="idError"></param>
        /// <param name="string_Key"></param>
        /// <param name="mensagem_adicional">Use a mensagem adicional com coisas úteis e específicas. Os textos genéricos devem ser criados um tipo em tabela Errors, para evitar consumo de log intenso.</param>
        /// <param name="user"></param>
        /// <param name="innerException"></param>
        public LoggerException(Exception innerException
                                    , EnumIdApp idApp
                                    , EnumIdLogLevel level
                                    , EnumIdError idError = EnumIdError.Undefined
                                    , string mensagem_adicional = ""
                                    , string? string_Key = null
                                    , string user = ""
                                    ) : base(mensagem_adicional, innerException)
        {
            var newLogMsg = new LogMsg()
            {
                IdApp = idApp,
                IdLogLevel = level,
                IdError = idError,
                ValueKeyFields = string_Key,
                TextLog = $"{mensagem_adicional} {innerException.Message}" ,
                LastUpdateUser = user,
                LastUpdateOn = DateTime.Now
            };

            LogsMsgs.Add(newLogMsg);
        }

        /// <summary>
        /// Gerar uma Exception a partir de um log.
        /// </summary>
        /// <param name="pLogMsg"></param>
        /// <param name="InnerException"></param>
        public LoggerException(Exception InnerException,
                                      LogMsg pLogMsg)
            : base(InnerException.Message, InnerException)
        {
            LogsMsgs.Add(pLogMsg);
        }

        /// <summary>
        /// Adicionar mensagens de logs adicionais para logar, ao capturar exception 
        /// na rotina main.
        /// </summary>
        /// <param name="pLogMsg">Informar n Object LogMsg</param>
        /// <returns></returns>
        public LoggerException AddAditionalLog(LogMsg pLogMsg)
        {
            var f = this.LogsMsgs.FirstOrDefault();
            var n = pLogMsg;
                (n.AppName, n.IdDomain, n.IdLogMsg, n.IdApp) 
              = (f.AppName, f.IdDomain, f.IdLogMsg, f.IdApp);
            this.LogsMsgs.Add(n);
            return this;
        }

        public LoggerException AddAditionalLog(EnumIdLogLevel level
                                                    , string message
                                                    , EnumIdError error = EnumIdError.Undefined
                                                    , string keyValueFields = "")
        {
            var newLog = new LogMsg()
            {
                IdLogLevel = level,
                TextLog = message,
                IdError = error,
                ValueKeyFields = keyValueFields 
            };
            var firstLog = this.LogsMsgs.LastOrDefault();
            if (firstLog != null)
            {
                newLog.IdError = firstLog.IdError;
                newLog.AppName = firstLog.AppName;
                newLog.IdDomain = firstLog.IdDomain;
                newLog.IdLogMsg = firstLog.IdLogMsg;
            }
            this.LogsMsgs.Add(newLog);
            return this;
        }
    }
    
}