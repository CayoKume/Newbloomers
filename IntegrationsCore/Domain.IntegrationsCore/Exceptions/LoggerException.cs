using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Errors;
using Domain.IntegrationsCore.Interfaces;
using System.Runtime.Serialization;

namespace Domain.IntegrationsCore.Exceptions
{
    public class LoggerException : Exception, ISerializable
    {
        //public IList<ILogMsg> LogsMsgs { get; private set; } = [];

        //public LoggerException(
        //    EnumMessageLevel idLevel,
        //    EnumIdMsgType idError,
        //    EnumSteps idStep,
        //    string message = "",
        //    string? string_Key = null
        //) : base(message)
        //{
        //    var newLogMsg = new LogMsg()
        //    {
        //        IdApp = EnumIdApp.Undefined,
        //        IdLogLevel = idLevel,
        //        IdError = idError,
        //        IdStep = idStep,
        //        ValueKeyFields = string_Key,
        //        TextLog = $"{message}"
        //    };

        //    LogsMsgs.Add(newLogMsg);
        //}

        //public LoggerException(
        //    Exception pInnerException,
        //    EnumMessageLevel idLevel,
        //    EnumIdMsgType idError, 
        //    EnumSteps idStep,
        //    string message = "",
        //    string? string_Key = null
        //) : base(message, pInnerException)
        //{
        //    var newLogMsg = new LogMsg()
        //    {
        //        IdApp = EnumIdApp.Undefined,
        //        IdLogLevel = idLevel,
        //        IdError = idError,
        //        IdStep = idStep,
        //        ValueKeyFields = string_Key,
        //        TextLog = $"{message} {pInnerException.Message}"
        //    };

        //    LogsMsgs.Add(newLogMsg);
        //}

        //public LoggerException(
        //    EnumIdApp idApp, 
        //    EnumMessageLevel level, 
        //    EnumIdMsgType idError = EnumIdMsgType.Undefined, 
        //    string message_log_detalhes_da_ocorrencia = "", 
        //    string? string_Key = null, 
        //    string user = "", 
        //    Exception? pInnerException = null
        //) : base(message_log_detalhes_da_ocorrencia, pInnerException)
        //{
        //    string msgError = string.Empty;
        //    if (pInnerException != null)
        //        msgError = pInnerException.Message;
        //    var newLogMsg = new LogMsg()
        //    {
        //        IdApp = idApp,
        //        IdLogLevel = level,
        //        IdError = idError,
        //        ValueKeyFields = string_Key,
        //        TextLog = $"{message_log_detalhes_da_ocorrencia} {msgError}",
        //        LastUpdateUser = user,
        //    };

        //    LogsMsgs.Add(newLogMsg);
        //}

        //public LoggerException(
        //    EnumIdMsgType idError, 
        //    EnumMessageLevel level, 
        //    EnumSteps steps, 
        //    string message_log_detalhes_da_ocorrencia = ""
        //) : base(message_log_detalhes_da_ocorrencia)
        //{
        //    var newLogMsg = new LogMsg()
        //    {
        //        IdStep = steps,
        //        IdLogLevel = level,
        //        IdError = idError,
        //        TextLog = $"{message_log_detalhes_da_ocorrencia}",
        //    };

        //    LogsMsgs.Add(newLogMsg);
        //}

        //public LoggerException (
        //    Exception innerException, 
        //    EnumIdApp idApp, 
        //    EnumMessageLevel level, 
        //    EnumIdMsgType idError = EnumIdMsgType.Undefined, 
        //    string mensagem_adicional = "", 
        //    string? string_Key = null, 
        //    string user = ""
        //) : base(mensagem_adicional, innerException)
        //{
        //    var newLogMsg = new LogMsg()
        //    {
        //        IdApp = idApp,
        //        IdLogLevel = level,
        //        IdError = idError,
        //        ValueKeyFields = string_Key,
        //        TextLog = $"{mensagem_adicional} {innerException.Message}",
        //        LastUpdateUser = user,
        //        LastUpdateOn = DateTime.Now
        //    };

        //    LogsMsgs.Add(newLogMsg);
        //}

        //public LoggerException (Exception InnerException,
        //                              LogMsg pLogMsg)
        //    : base(InnerException.Message, InnerException)
        //{
        //    LogsMsgs.Add(pLogMsg);
        //}

        //public LoggerException  AddLog(ILogMsg pLogMsg)
        //{
        //    var f = this.LogsMsgs.FirstOrDefault();
        //    var n = pLogMsg;
        //    (n.AppName, n.IdDomain, n.IdLogMsg, n.IdApp)
        //  = (f.AppName, f.IdDomain, f.IdLogMsg, f.IdApp);
        //    this.LogsMsgs.Add(n);
        //    return this;
        //}

        //public LoggerException  AddLog(
        //    EnumSteps step,
        //    EnumIdMsgType error,
        //    EnumMessageLevel level,
        //    string message, 
        //    string keyValueFields = ""
        //)
        //{
        //    var newLog = new LogMsg()
        //    {
        //        IdLogLevel = level,
        //        TextLog = message,
        //        IdError = error,
        //        ValueKeyFields = keyValueFields
        //    };
        //    var firstLog = this.LogsMsgs.LastOrDefault();
        //    if (firstLog != null)
        //    {
        //        newLog.AppName = firstLog.AppName;
        //        newLog.IdDomain = firstLog.IdDomain;
        //    }
        //    this.LogsMsgs.Add(newLog);
        //    return this;
        //}
    }
    
}