using Application.IntegrationsCore.Interfaces;
using Domain.IntegrationsCore.Entities.Auditing;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Interfaces;
using Org.BouncyCastle.Asn1.Pkcs;
using System.Security.Cryptography;
using System.Text;

namespace Application.IntegrationsCore.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogRepository _logRepository;
        public Log? log { get; private set; }

        public LoggerService(ILogRepository logRepository) =>
            _logRepository = logRepository;

        public ILoggerService AddLog(EnumJob job)
        {
            this.log ??= new Log(job: job);

            return this;
        }

        public ILoggerService AddMessage(
            EnumStages stage,
            EnumError error,
            EnumMessageLevel logLevel,
            string message,
            string exceptionMessage,
            string commandSQL
        )
        {
            this.log?.Messages.Add(
                new Message(
                    stage: stage,
                    error: error,
                    logLevel: logLevel,
                    message: message,
                    exceptionMessage: exceptionMessage,
                    commandSQL: commandSQL,
                    execution: this.log.Execution
                )
            );

            return this;
        }

        public ILoggerService AddMessage(
            EnumStages stage,
            EnumError error,
            EnumMessageLevel logLevel,
            string message,
            string exceptionMessage
        )
        {
            this.log?.Messages.Add(
                new Message(
                    stage: stage,
                    error: error,
                    logLevel: logLevel,
                    message: message,
                    exceptionMessage: exceptionMessage,
                    execution: this.log.Execution
                )
            );

            return this;
        }

        public ILoggerService AddMessage(
            EnumStages stage,
            EnumError error,
            EnumMessageLevel logLevel,
            string message
        )
        {
            this.log?.Messages.Add(
                new Message(
                    stage: stage,
                    error: error,
                    logLevel: logLevel,
                    message: message,
                    execution: this.log.Execution
                )
            );

            return this;
        }

        public ILoggerService AddMessage(string message, string exceptionMessage)
        {
            this.log?.Messages.Add(
                new Message(
                    message: message,
                    exceptionMessage: exceptionMessage,
                    execution: this.log.Execution
                )
            );

            return this;
        }

        public ILoggerService AddMessage(string message)
        {
            this.log?.Messages.Add(
                new Message(
                    message: message,
                    guidExecution: this.log.Execution
                )
            );

            return this;
        }

        public ILoggerService AddRecord(string key, string xml)
        {
            this.log?.Records.Add(
                new Record(key: key, regXML: xml)
            );

            return this;
        }

        public ILoggerService SetLogEndDate()
        {
            if (this.log != null)
                this.log.SetEndDate(DateTime.Now);

            return this;
        }

        public ILoggerService Clear()
        {
            this.log?.Records.Clear();

            return this;
        }

        public async Task CommitAllChanges()
        {
            await _logRepository.LogInsert(this.log);
        }

        public Guid? GetExecutionGuid()
        {
            return this.log.Execution;
        }

        public string ComputeSha256Hash(string json)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(json));
            return Convert.ToHexString(bytes);
        }
    }
}


